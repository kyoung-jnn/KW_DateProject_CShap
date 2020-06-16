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
    public partial class IdealList : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        string Gender;
        string[] ideals = new string[10];
        public IdealList(string myId,string myGender, string idealId)
        {
            InitializeComponent();
            Gender = myGender;
            SetData(myId, idealId);
        }
        private void SetData(string myId, string idealId)
        {
            GetData(myId);
            for (int i = 0; i < ideals.Length; i++)
            {
                //if (ideals[i] != "")
                //break;

                object[] dr = new object[6];
                byte[] Image = null;

                try
                {
                    string ReadQuery = "";

                    //사진 불러오기
                    if (Gender == "남자")
                        ReadQuery = "SELECT file from profile_photo_data_f WHERE id=" + ideals[i];
                    else if (Gender == "여자")
                        ReadQuery = "SELECT file from profile_photo_data_m WHERE id=" + ideals[i];
                    connection.Open();
                    // myId로 Mysql에서 가져옴

                    MySqlCommand cmd1 = new MySqlCommand(ReadQuery, connection);
                    MySqlDataReader table1 = cmd1.ExecuteReader();
                    if (table1.Read())
                    {
                        Image = (byte[])table1[0];
                        dr[0] = new Bitmap(new MemoryStream(Image));
                    }

                    table1.Close();
                    connection.Close();
                    //나머지 정보 불러오기
                    if (Gender == "남자")
                        ReadQuery = "SELECT * from user_data_f WHERE id=" + ideals[i];
                    else if (Gender == "여자")
                        ReadQuery = "SELECT * from user_data_m WHERE id=" + ideals[i];
                    connection.Open();
                    // myId로 Mysql에서 가져옴
                    MySqlCommand cmd2 = new MySqlCommand(ReadQuery, connection);
                    MySqlDataReader table2 = cmd2.ExecuteReader();
                    
                    table2.Read();
                    dr[1] = table2["name"];
                    dr[2] = table2["age"];
                    dr[3] = table2["department"];


                    dr[4] = new Button();
                    dr[5] = new Button();
                    ((Button)dr[4]).MouseClick += btnChat_Click;
                    ((Button)dr[5]).MouseClick += btnDel_Click;
                    table2.Close();
                    connection.Close();

                    dataGridView1.Rows.Add(dr);
                }
                catch 
                {
                    break;
                }
            }
        }
        private void GetData(string myId)       //mysql에 이상형들이 저장되어있으면 불러오기
        {
            try
            {
                connection.Open();
                // myId로 Mysql에서 가져옴

                string ReadQuery = "SELECT * FROM ideal_list where id = " + myId;

                MySqlCommand cmd = new MySqlCommand(ReadQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                for (int i = 1; i < 11; i++)
                {
                    string col = "ideal" + i + "_id";
                    if (table.Read()) // 이상형 데이터 읽기
                    {
                        if (table[col].ToString() != "")
                        {
                            ideals[i - 1] = table[col].ToString();
                        }
                        else
                        {
                            break;      //빈 column까지 읽으면 탈출
                        }
                    }
                }

                table.Close();
                connection.Close();
            }
            catch { }
        }
        private void btnChat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender).Controls.ToString());
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!");
        }
    }
}
