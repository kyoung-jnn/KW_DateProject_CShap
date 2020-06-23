﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

using System.IO;

namespace KW_Project
{
   
    public partial class btnBoardShare : Form
    {
        
        private const int CS_DROPSHADOW = 0x00020000;
        private string currentUserId = null;
        private string currentUserGender = null;
        public string filepath = null;
       public bool checkAddOrUpdate = false;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public btnBoardShare(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            InitializeComponent();
            loadRecentPhoto();
           
        }
        private void loadPicAdder()
        {
            string insertQuery = "";
            string readQuery = "";
            UInt32 fileSize;
            byte[] data;
            FileStream fs;
            MySqlCommand command = new MySqlCommand();


            // user_data table에 성별 읽어오고
            if (currentUserGender == "남자")
                readQuery = "SELECT * FROM user_data_m WHERE id=" + currentUserId;
            else if (currentUserGender == "여자")
                readQuery = "SELECT * FROM user_data_f WHERE id=" + currentUserId;

            connection.Open();

            // 성별 읽어오기
            MySqlCommand cmd = new MySqlCommand(readQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            table.Read();
            currentUserGender = table["gender"].ToString();
            table.Close();

            connection.Close();

            //이건 업데이트
            //     * insertQuery = "UPDATE board_data_m SET fileSize=@fileSize,file=@file WHERE id = @id";
            //   * 이거 등록
            // insertQuery = "INSERT INTO board_data_m VALUES(" + currentUserId + " , " + "@gender,@fileSize,@file)"

            // 사진 등록
            if (currentUserGender == "남자")
                insertQuery = "INSERT INTO board_data_m VALUES(" + currentUserId + " , " + "@gender,@fileSize,@file)";
            else if (currentUserGender == "여자")
                insertQuery = "INSERT INTO board_data_f VALUES(" + currentUserId + " , " + "@gender,@fileSize,@file)";

            try
            {
                fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                fileSize = (UInt32)fs.Length;
                data = new byte[fileSize];
                fs.Read(data, 0, (int)fileSize);

                fs.Close();

                connection.Open();

                command.Connection = connection;
                command.CommandText = insertQuery;
                //command.Parameters.AddWithValue("@id", currentUserId);
                command.Parameters.AddWithValue("@gender", currentUserGender);
                command.Parameters.AddWithValue("@file", data);
                command.Parameters.AddWithValue("@fileSize", fileSize);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("업로드 완료!");
                    }
                    else
                    {
                        MessageBox.Show("업로드 실패");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                             , int nTopRect
                                             , int nRightRect
                                             , int nBottomRect
                                             , int nWidthEllipse
                                             , int nHeightEllipse);

       

        private void btnBoardShare_Load(object sender, EventArgs e)
        {
            //테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
        }
        //뒤로가기
        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        //사진 불러오기
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    //현 사진 출력
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //최근 일상 불러오기
        private void loadRecentPhoto()
        {
            string insertQuery = "";
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT file from board_data_m WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT file from board_data_f WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Image = (byte[])reader[0];
                    pictureBox1.Image = new Bitmap(new MemoryStream(Image));
                    checkAddOrUpdate = true;
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
       
        //업로드하기
        private void BtnMainshare_Click(object sender, EventArgs e)
        {
            if (checkAddOrUpdate != true )
            {
                loadPicAdder();
            }
            else
            {
                UInt32 fileSize;
                BinaryReader br;
                FileStream fs;
                byte[] ImageData;
                fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                fileSize = (UInt32)fs.Length;
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);

                connection.Open();

                // 사진 업데이트
                string insertQuery = "";
                if (currentUserGender == "남자")
                    insertQuery = "UPDATE board_data_m SET fileSize=@fileSize,file=@file WHERE id = @id";
                else if (currentUserGender == "여자")
                    insertQuery = "UPDATE board_data_f SET fileSize=@fileSize,file=@file WHERE id = @id";

                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@id", currentUserId);
                command.Parameters.Add("@file", MySqlDbType.Blob);
                command.Parameters.AddWithValue("@fileSize", fileSize);
                command.Parameters["@file"].Value = ImageData;

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("업로드 성공!");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("업로드 실패");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                br.Close();
                fs.Close();
                connection.Close();


                this.Close();


               
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
      
    }
}
