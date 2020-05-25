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

namespace KW_Project
{
    public partial class ProfilePhoto : Form
    {
        private string currentUserId;
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

        public string filePath;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    profilePic.Image = Image.FromFile(openFileDialog1.FileName);
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
            UInt32 fileSize;
            byte[] data;
            FileStream fs;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            insertQuery = "INSERT INTO profile_photo_data VALUES(" + currentUserId + " , "+"@fileName,@fileSize,@file)"; 

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); // 해당 filePath에 stream 열기
                fileSize = (UInt32)fs.Length;

                data = new byte[fileSize];
                fs.Read(data, 0, (int)fileSize);
                fs.Close();

                connection.Open(); // mysql 연결

                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@fileName", filePath);
                command.Parameters.AddWithValue("@fileSize", fileSize);
                command.Parameters.AddWithValue("@file", data);

                command.ExecuteNonQuery();

                MessageBox.Show("전송 성공"); //지워야함

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // mysql에서 사진 불러오기
        /*private void btnLoadfromWin_Click(object sender, EventArgs e)
        {
            string fileName;
            string insertQuery;
            UInt32 fileSize;
            byte[] data;
            FileStream fs;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=8983");
            MySqlCommand command = new MySqlCommand();

            insertQuery = "SELECT * from profile_photo_data";

            try
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = insertQuery;

                MySqlDataReader myData = command.ExecuteReader();

                *//*if (!myData.HasRows)
                    throw new Exception("Blob 데이터가 존재하지 않습니다.");*//*

                myData.Read();

                fileSize = myData.GetUInt32(myData.GetOrdinal("filesize"));
                data = new byte[fileSize];

                myData.GetBytes(myData.GetOrdinal("file"), 0, data, 0, (int)fileSize);

                fileName = @System.IO.Directory.GetCurrentDirectory() + "\\newfile.png";

                fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(data, 0, (int)fileSize);
                fs.Close();

                //profilePic2.Image = Image.FromFile(fileName);

                myData.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }*/

        

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
