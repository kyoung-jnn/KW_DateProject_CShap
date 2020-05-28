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
    public partial class FirstSettingForm : Form
    {
        public FirstSettingForm()
        {
            InitializeComponent();
        }


        private void FirstSettingForm_Load(object sender, EventArgs e)
        {
            // 테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                      , int nTopRect
                                                      , int nRightRect
                                                      , int nBottomRect
                                                      , int nWidthEllipse
                                                      , int nHeightEllipse);

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string filepath = null;// 받아온 파일 경로
        //사진 등록/수정 버튼 클릭 시
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   filepath = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*string image = string.Empty;
            
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                image = dialog.FileName;

            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {

                return;

            }
            pictureBox1.Image = Bitmap.FromFile(image);
           */



        }

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        loginForm login_user = new loginForm();
        private void CircleButton1_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd;
            BinaryReader br;
            FileStream fs;
            byte[] ImageData;
            fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);

            connection.Open();

            MessageBox.Show("쿼리문 실행"); // 나중에 없앨거임

            // 학번, 비밀번호 전송//update u
            string insertQuery = "UPDATE user_data SET Image = '@Image' WHERE id = 2016726026";
            
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.Parameters.Add("@Image", MySqlDbType.Blob);

            command.Parameters["@Image"].Value = ImageData;
            
            
            
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("저장 완료!");
                    connection.Close();
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
            /*

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("입력 정보를 확인하세요!");
                return;
            }

            try
            {
                connection.Open();
                // 현재 입력한 학번으로 Mysql에서 가져옴
                string ReadQuery = "SELECT * FROM user_data where image = " + pictureBox1.Image;

                MySqlCommand cmd = new MySqlCommand(ReadQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                if (table.Read())
                {
                    if (txtId.Text == table["id"].ToString() && txtPwd.Text == table["pwd"].ToString())
                    {
                        this.Visible = false; // 로그인 창 닫아놓기
                        MainMenu mM = new MainMenu();
                        DialogResult result = mM.ShowDialog();


                        if (result == DialogResult.Cancel)
                        {
                            this.Visible = true;
                        }
                    }
                }
                else // database에 정보가 없음
                {
                    MessageBox.Show("회원 정보가 없습니다.");
                }

                table.Close();
                connection.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("DataBase 읽기 실패");
                MessageBox.Show(E.ToString());
            }
            */
        }
    }
    
}
