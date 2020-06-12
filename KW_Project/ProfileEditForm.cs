﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Mysql 사용
using System.IO;

namespace KW_Project
{
    public partial class ProfileEditForm : Form
    {
        private string currentUserId;
        private string currentUserGender;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=100984");

        public ProfileEditForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            InitializeComponent();
            loadProfilePhoto(); // 현재 프로필 불러오기
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                      , int nTopRect
                                                      , int nRightRect
                                                      , int nBottomRect
                                                      , int nWidthEllipse
                                                      , int nHeightEllipse);

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string filepath = null;// 받아온 파일 경로
        private void profilePic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    profilePic.Image = Image.FromFile(openFileDialog1.FileName);
                    profilePic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            MessageBox.Show("쿼리문 실행"); // 나중에 없앨거임

            // 프로필 사진 업데이트
            string insertQuery = "UPDATE profile_photo_data SET fileSize=@fileSize,file=@file WHERE id = @id";

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@id", currentUserId);
            command.Parameters.Add("@file", MySqlDbType.Blob);
            command.Parameters.AddWithValue("@fileSize", fileSize);
            command.Parameters["@file"].Value = ImageData;

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

            br.Close();
            fs.Close();
            connection.Close();
            
            //프로필 수정 창 닫기
            this.Close();
        }

        // mysql에서 프로필 사진 불러오기
        private void loadProfilePhoto()
        {
            string insertQuery;
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            insertQuery = "SELECT file from profile_photo_data WHERE id=@id";

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
                    profilePic.Image = new Bitmap(new MemoryStream(Image));
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
