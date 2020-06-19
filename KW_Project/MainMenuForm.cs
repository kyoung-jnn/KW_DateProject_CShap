using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Mysql 사용
using System.IO;

namespace KW_Project
{
    public partial class MainMenuForm : Form
    {
        private string currentUserId;
        private string currentUserGender;
        private const int CS_DROPSHADOW = 0x00020000;
        public string idealId = string.Empty; // 현재 화면에 나와있는 이성 ID
        private string[] myIdealAttraction;
        private Dictionary<int, string> idealList = new Dictionary<int, string>(); // 이성 프로필 전부 저장
        private Dictionary<int, int> idealCount = new Dictionary<int, int>();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                    , int nTopRect
                                                    , int nRightRect
                                                    , int nBottomRect
                                                    , int nWidthEllipse
                                                    , int nHeightEllipse);

        public MainMenuForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            //btnHome.Enabled = false;

            InitializeComponent();
            lblProfile1.Parent = idealPic;
            lblProfile2.Parent = idealPic;

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            //테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

            // 매칭 알고리즘
            MatchingAlgorithm();

            if (currentUserGender == "남자")
                idealId = MatchingAlgorithm();
            else if (currentUserGender == "여자")
                idealId = MatchingAlgorithm();

            //매칭 알고리즘 구현시 31~35줄 수정해서 ideal_id를 매칭된 사람으로 해주면 댈듯?? -->6/16일 추가 : 전역변수로 idealId만들었으니 여기 할당해주면 댐
            //취소버튼 누르면 다시 다른사람 매칭해서 밑에 함수 두개 실행시켜주는식으로
            LoadIdealPhoto();
            LoadIdealProfile();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileEditForm profileeditform = new ProfileEditForm(currentUserId, currentUserGender);
            profileeditform.ShowDialog();
        }

        // mysql에서 프로필 사진 불러오기
        private void LoadIdealPhoto()
        {
            string insertQuery = "";
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT file from profile_photo_data_f WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT file from profile_photo_data_m WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", idealId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Image = (byte[])reader[0];
                    idealPic.Image = new Bitmap(new MemoryStream(Image));
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void LoadIdealProfile()
        {
            string insertQuery = "";

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT * from user_data_f WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT * from user_data_m WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", idealId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblProfile1.BackColor = System.Drawing.Color.Transparent;
                    lblProfile1.Text = reader["department"].ToString();
                    lblProfile1.Text += " ";
                    lblProfile1.Text += reader["age"].ToString();

                    lblProfile2.BackColor = System.Drawing.Color.Transparent;
                    lblProfile2.Text = reader["name"].ToString();
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        private void btnBoard_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            BoardForm boardForm = new BoardForm(currentUserId,currentUserGender);
            DialogResult result = boardForm.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private string MatchingAlgorithm()
        {
            string insertQuery = "";
            int idealCnt = 0; // 일치하는 매력 총합
            int idealId = 0;  // 가장 적합한 이성
            bool flag = false; // 이상형 비교시 첫번째 비교할 이상형인지 확인하는 용

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader reader;

            if (currentUserGender == "남자")
                insertQuery = "SELECT user_data_m.ideal from project_data.user_data_m WHERE id=@curID;";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT user_data_f.ideal from project_data.user_data_f WHERE id=@curID;";

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@curId", currentUserId);

                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string mIdeal = reader["ideal"].ToString();

                    // 자신의 ideal 저장
                    myIdealAttraction = mIdeal.Split('_');
          
                }

                reader.Close();
                connection.Close();

                // 이성의 attraction 가져와 자신의 ideal과 비교
                switch (currentUserGender)
                {
                    case "남자":
                        {
                            insertQuery = "SELECT id,user_data_f.attraction from project_data.user_data_f";

                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = insertQuery;

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                // DB에서 모든 이성의 데이터 가져오기
                                if(idealList.ContainsKey(Convert.ToInt32(reader[0])) == false)
                                    idealList.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                            }

                            reader.Close();
                            connection.Close();

                            break;
                        }
                    case "여자":
                        {
                            insertQuery = "SELECT id,user_data_m.attraction from project_data.user_data_m";

                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = insertQuery;

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                // DB에서 모든 이성의 데이터 가져오기
                                idealList.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                            }

                            reader.Close();
                            connection.Close();

                            break;
                        }
                }

                foreach(var pair in idealList)
                {
                    int Cnt = 0;

                    string[]idealAttraction = pair.Value.Split('_');
                    for(int i=0; i < myIdealAttraction.Length-1; i++)
                    {
                        if (idealAttraction.Contains(myIdealAttraction[i]))
                            Cnt++;
                    }
                    if (idealCount.ContainsKey(pair.Key) == false)
                        idealCount.Add(pair.Key, Cnt);
                }

                
                foreach(var pair in idealCount)
                {
                    if(flag == false)
                    {
                        idealId = pair.Key;
                        idealCnt = pair.Value;
                        flag = true;
                    }
                    else
                    {
                        if(pair.Value >= idealCnt)
                        {
                            idealId = pair.Key;
                            idealCnt = pair.Value;
                        }
                    }
                }

                // 적합한 이성의 ID Return
                return idealId.ToString();
            }
            catch(Exception e){
                MessageBox.Show(e.ToString());
                return "알고리즘실패";
            }
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

            string insertQuery = null;
            if (currentUserGender == "남자")
                insertQuery = "UPDATE user_data_m SET ideal_id=@ideal_id WHERE id=@curID;";
            else if (currentUserGender == "여자")
                insertQuery = "UPDATE user_data_f SET ideal_id=@ideal_id WHERE id=@curID;";

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@curID", currentUserId);
                command.Parameters.AddWithValue("@ideal_id", idealId + "_");
         
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("좋아요한 이상형 전송"); // 나중에 지움
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            /*
            //this.Visible = false;
            ChatClientForm clientForm = new ChatClientForm();
            DialogResult result = clientForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
            */
            IdealListForm idealList = new IdealListForm(currentUserId, currentUserGender);
            idealList.ShowDialog();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {

        }
    }

}

