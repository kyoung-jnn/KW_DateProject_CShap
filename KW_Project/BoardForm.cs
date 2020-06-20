using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace KW_Project
{
    public partial class BoardForm : Form
    {
        private string currentUserId;
        private string currentUserGender;
        private string[] LoadAllUsersFeed;
        
        private const int CS_DROPSHADOW = 0x00020000;
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        public BoardForm(string id,string gender)
        {

            currentUserId = id;
            currentUserGender = gender;
        
            InitializeComponent();
           

        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                    , int nTopRect
                                                    , int nRightRect
                                                    , int nBottomRect
                                                    , int nWidthEllipse
                                                    , int nHeightEllipse);
        /*

        private void GetData()
        {
            try
            {
                con.Open();
                string ReadQuery = null;
                if (currentUserGender == "남자")
                    ReadQuery = "SELECT * from board_data_f WHERE id>10000000;";
                else if (currentUserGender == "여자")
                    ReadQuery = "SELECT * from board_data_m WHERE id>10000000;";

                MySqlCommand command = new MySqlCommand(ReadQuery, con);
                
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string allpic = reader.ToString();
                    //게시판 ID들 저장
                    LoadAllUsersFeed = allpic.Split('_');
                }
                reader.Close();
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        */
        private void connectData()
        {
            
            MySqlCommand query = con.CreateCommand();
            /*
                        DataGridViewImageColumn imageCell = new DataGridViewImageColumn();
                        imageCell.Name = "file";
                        imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        imageCell.Width = 180;

                        dataGridView1.Columns.Add(imageCell);
                        dataGridView1.Columns["file"].DisplayIndex = 0;
            
            DataGridViewImageColumn img1 = new DataGridViewImageColumn();
            img1.Name = "file";
            img1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img1.Width = 180;
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.Name = "file2";
            img2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img2.Width = 180;
            DataGridViewImageColumn img3 = new DataGridViewImageColumn();
            img3.Name = "file3";
            img3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img3.Width = 180;
            dataGridView1.RowTemplate.Height = 180;
            dataGridView1.Columns.Add(img1);
           dataGridView1.Columns["file"].DisplayIndex = 0;
            dataGridView1.Columns.Add(img2);
            dataGridView1.Columns["file2"].DisplayIndex = 1;
            dataGridView1.Columns.Add(img3);
            dataGridView1.Columns["file3"].DisplayIndex = 2;
            */





             if (currentUserGender == "남자")
                  query.CommandText = "SELECT * from board_data_f";
             else if (currentUserGender == "여자") 
            query.CommandText = "SELECT * from board_data_f ";
          
          
            try
            {
                con.Open();

                MySqlDataReader reader = query.ExecuteReader();
             
               dataGridView1.Rows.Clear();
            
                for (int i = 0; reader.Read(); i++)
                {

                    dataGridView1.Rows.Add();
           
                    dataGridView1.Rows[i].Cells["file"].Value = reader["file"];


                    
                }
            }catch(Exception e)
            {
                return;
            }
            finally
            {
                con.Close();
            }
        }
        private void BoardForm_Load(object sender, EventArgs e)
        {
            //테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

           

           

            connectData(); //그 아이디에 해당하는 사진들을 모두 불러온다.
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
     

     

        /*
        private void loadAllUsers()
        {
            string insertQuery = "";
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
           
            connection.Open();
           
            
            try
            {
                //게시판 1번 사진   
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                //
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001001";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001001";
                
                command.CommandText = insertQuery;                               
                command.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader1 = command.ExecuteReader();
                if (reader1.Read())
                {
                    Image = (byte[])reader1[0];
                    pictureBox1.Image = new Bitmap(new MemoryStream(Image));                    
                }
                reader1.Close();
                //게시판 2번 사진 command, reader재정의
              //  insertQuery = "";
             //   Image = null;
                MySqlCommand command2 = new MySqlCommand();
                command2.Connection = connection;
                //
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001002";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001002";

                command2.CommandText = insertQuery;
                command2.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    Image = (byte[])reader2[0];
                    pictureBox2.Image = new Bitmap(new MemoryStream(Image));
                }
                reader2.Close();
                //게시판 3번 사진 command, reader재정의
                
                MySqlCommand command3 = new MySqlCommand();
                command3.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001003";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001003";

                command3.CommandText = insertQuery;
                command3.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader3 = command3.ExecuteReader();
                if (reader3.Read())
                {
                    Image = (byte[])reader3[0];
                    pictureBox3.Image = new Bitmap(new MemoryStream(Image));
                }
                reader3.Close();
                //
                //게시판 4번 사진 command, reader재정의

                MySqlCommand command4 = new MySqlCommand();
                command4.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001004";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001004";

                command4.CommandText = insertQuery;
                command4.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader4 = command4.ExecuteReader();
                if (reader4.Read())
                {
                    Image = (byte[])reader4[0];
                    pictureBox4.Image = new Bitmap(new MemoryStream(Image));
                }
                reader4.Close();
                // //게시판 5번 사진 command, reader재정의

                MySqlCommand command5 = new MySqlCommand();
                command5.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001005";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001005";

                command5.CommandText = insertQuery;
                command5.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader5 = command5.ExecuteReader();
                if (reader5.Read())
                {
                    Image = (byte[])reader5[0];
                    pictureBox5.Image = new Bitmap(new MemoryStream(Image));
                }
                reader5.Close();
                // //게시판 6번 사진 command, reader재정의

                MySqlCommand command6 = new MySqlCommand();
                command6.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001006";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001006";

                command6.CommandText = insertQuery;
                command6.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader6 = command6.ExecuteReader();
                if (reader6.Read())
                {
                    Image = (byte[])reader6[0];
                    pictureBox6.Image = new Bitmap(new MemoryStream(Image));
                }
                reader6.Close();
                //게시판 7번 사진 command, reader재정의

                MySqlCommand command7 = new MySqlCommand();
                command7.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001007";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001007";

                command7.CommandText = insertQuery;
                command7.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader7 = command7.ExecuteReader();
                if (reader7.Read())
                {
                    Image = (byte[])reader7[0];
                    pictureBox7.Image = new Bitmap(new MemoryStream(Image));
                }
                reader7.Close();
                //게시판 8번 사진 command, reader재정의

                MySqlCommand command8 = new MySqlCommand();
                command8.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001008";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001008";

                command8.CommandText = insertQuery;
                command8.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader8 = command8.ExecuteReader();
                if (reader8.Read())
                {
                    Image = (byte[])reader8[0];
                    pictureBox8.Image = new Bitmap(new MemoryStream(Image));
                }
                reader8.Close();
                //게시판 9번 사진 command, reader재정의

                MySqlCommand command9 = new MySqlCommand();
                command9.Connection = connection;
                if (currentUserGender == "남자")
                    insertQuery = "SELECT file from board_data_m WHERE id=2016001009";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT file from board_data_f WHERE id=2016001009";

                command9.CommandText = insertQuery;
                command9.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader9 = command9.ExecuteReader();
                if (reader9.Read())
                {
                    Image = (byte[])reader9[0];
                    pictureBox9.Image = new Bitmap(new MemoryStream(Image));
                }
                reader9.Close();

                connection.Close();
            }
            catch (Exception ex){ MessageBox.Show("게시판 점검중!!"); }
            

        }
        */

        private void BtnShare_Click(object sender, EventArgs e)
        {
            btnBoardShare bbs = new btnBoardShare(currentUserId,currentUserGender);
            bbs.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
    
