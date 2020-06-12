using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Mysql 사용
using System.Threading;

namespace KW_Project
{
    public partial class ProfilePhoto : Form
    {
        private string currentUserId;
        private string currentUserGender;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=100984");

        public ProfilePhoto(string id)
        {
            currentUserId = id;
            InitializeComponent();
        }

        private void ProfilePhoto_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                     , int nTopRect
                                                     , int nRightRect
                                                     , int nBottomRect
                                                     , int nWidthEllipse
                                                     , int nHeightEllipse);

        public string filePath = null; // 받아온 파일 경로
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
           
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    profilePic.Image = Image.FromFile(openFileDialog1.FileName);
                    profilePic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void btnSavetoDB_Click(object sender, EventArgs e)
        {
            string insertQuery;
            string readQuery;
            UInt32 fileSize;
            byte[] data;
            FileStream fs;
            MySqlCommand command = new MySqlCommand();

            // profile table에 성별 등록
            readQuery = "SELECT * FROM user_data WHERE id=" + currentUserId;

            connection.Open();

            // 성별 읽어오기
            MySqlCommand cmd = new MySqlCommand(readQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            table.Read();
            currentUserGender = table["gender"].ToString();
            table.Close();

            connection.Close();

            //

            // 사진 등록
            insertQuery = "INSERT INTO profile_photo_data VALUES(" + currentUserId + " , "+"@gender,@fileSize,@file)"; 

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); // 해당 filePath에 stream 열기
                fileSize = (UInt32)fs.Length;
                data = new byte[fileSize];
                fs.Read(data, 0, (int)fileSize); // 사진 데이터 스트림으로 받기

                fs.Close();

                connection.Open(); // mysql 연결

                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@gender", currentUserGender);
                command.Parameters.AddWithValue("@file", data);
                command.Parameters.AddWithValue("@fileSize", fileSize);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("저장 완료!");
                    }
                    else
                    {
                        MessageBox.Show("비정상 전송");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.DialogResult = DialogResult.No; // form 을 아예 종료

            // 로딩 창
            LoadingForm loadingform = new LoadingForm();
            DialogResult result = loadingform.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                // 메인 메뉴 띄우기 테스트
                MainMenuForm mainform = new MainMenuForm(currentUserId, currentUserGender);
                mainform.Show();
            }
      
   
        }
    }
}
