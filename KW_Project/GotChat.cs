﻿using System;
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
    public partial class GotChat : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        private string currentUserId;
        private string currentUserGender;
        private List<string> myIdealList = new List<string>();

        public GotChat(string myId, string myGender)
        {
            InitializeComponent();
            currentUserId = myId;
            currentUserGender = myGender;
        }
        private void GotChat_Load(object sender, EventArgs e)
        {
            // Image Col 추가 
            DataGridViewImageColumn ImageCol = new DataGridViewImageColumn();
            ImageCol.Name = "사진";
            ImageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ImageCol.Width = 180;

            dataGridView1.Columns.Add(ImageCol);
            
            dataGridView1.Columns["사진"].DisplayIndex = 0;

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 95;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[4].Width = 45;

            dataGridView1.RowTemplate.Height = 180;



            //GetData(currentUserId); // 나를 좋아요 누른 사람들 ID 불러오기

            SetData(); // 불러온 ID로 리스트 만들기
        }

        private void SetData()
        {
            object[] dr = new object[6];
            byte[] Image = null;

            /* for (int i = 0; i < myIdealList.Count; i++)
             {*//*
                             object[] dr = new object[6];


                 try
                 {
                     string ReadQuery = "";

                     //
                     //
                     //사진 불러오기
                     if (currentUserGender == "남자")
                         ReadQuery = "SELECT file from profile_photo_data_f WHERE id=" + myIdealList[i];
                     else if (currentUserGender == "여자")
                         ReadQuery = "SELECT file from profile_photo_data_m WHERE id=" + myIdealList[i];

                     connection.Open();
                     MySqlCommand cmd1 = new MySqlCommand(ReadQuery, connection);
                     MySqlDataReader table1 = cmd1.ExecuteReader();
                     if (table1.Read())
                     {
                         Image = (byte[])table1[0];
                     }
                     table1.Close();
                     connection.Close();


                     //
                     //
                     //나머지 정보 불러오기
                     if (currentUserGender == "남자")
                         ReadQuery = "SELECT * from user_data_f WHERE id=" + myIdealList[i];
                     else if (currentUserGender == "여자")
                         ReadQuery = "SELECT * from user_data_m WHERE id=" + myIdealList[i];

                     connection.Open();
                     MySqlCommand cmd2 = new MySqlCommand(ReadQuery, connection);
                     MySqlDataReader table2 = cmd2.ExecuteReader();

                     if (table2.Read())
                     {
                        
                         //
                         // 채팅 버튼
                      *//*   dr[3] = new Button();
                         dr[4] = new Button();*//*
                     }

                     table2.Close();
                     connection.Close();*/
                dr[0] = "이민호";
                dr[1] = "26";
                dr[2] = "컴소";
                dr[3] = new Button();
                dr[4] = new Button();
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4],null);

                try
                { 
                    

                    //dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], new Bitmap(new MemoryStream(Image)));
                    
            
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                foreach (DataGridViewRow obj in dataGridView1.Rows)
                {
                    obj.Cells[3].Value = "채팅";
                    obj.Cells[4].Value = "삭제";
                }
        }

        private void GetData(string myId)       //mysql에 이상형들이 저장되어있으면 불러오기
        {
            try
            {
                connection.Open();
                // myId로 Mysql에서 가져옴

                string ReadQuery = null;

                if (currentUserGender == "남자")
                    ReadQuery = "SELECT ideal_id from project_data.user_data_m WHERE id=@curID;";
                else if (currentUserGender == "여자")
                    ReadQuery = "SELECT ideal_id from project_data.user_data_f WHERE id=@curID;";

                MySqlCommand command = new MySqlCommand(ReadQuery, connection);
                command.Parameters.AddWithValue("@curID", currentUserId);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string[] mIdeals = (reader["ideal_id"].ToString()).Split('_');
                    // 이상형 ID들 저장
                    for (int i = 0; i < mIdeals.Length - 1; i++)
                    {
                        myIdealList.Add(mIdeals[i]);
                    }
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("test");
            DataGridView grid = (DataGridView)sender;
            int intRow = e.RowIndex;
            int intCol = e.ColumnIndex;

            Type typeObject = grid.Rows[intRow].Cells[intCol].GetType();
            switch (intCol)
            {
                case 3:
                    //채팅 신청버튼 클릭
                    btn_Chat(intRow);
                    break;
                case 4:
                    //삭제 버튼 클릭
                    btn_Del(intRow);
                    break;
            }
        }
        private void btn_Chat(int intRow)
        {
            ChatClientForm client = new ChatClientForm();
            client.Show();
        }
        private void btn_Del(int intRow)
        {
            string readQuery = "";
            string insertQuery = "";
            string old = string.Empty;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader reader;

            // selected_ideal 초기화
            if (currentUserGender == "남자")
                readQuery = "SELECT ideal_id from user_data_m where id=@curId";
            else if (currentUserGender == "여자")
                readQuery = "SELECT ideal_id from user_data_f where id=@curId";

            connection.Open();

            command = new MySqlCommand(readQuery, connection);
            command.Parameters.AddWithValue("@curID", currentUserId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                old = reader["ideal_id"].ToString();
                string del_id = myIdealList[intRow];

                old.Replace(del_id + "_", "");
                myIdealList.Remove(del_id);
            }
            reader.Close();
            connection.Close();
            dataGridView1.Rows.Remove(dataGridView1.Rows[intRow]);

            string new_ideals = string.Empty;
            for (int i = 0; i < myIdealList.Count; i++)
            {
                new_ideals += myIdealList[i] + "_";
            }
            // ideal_id 다시 저장
            if (currentUserGender == "남자")
                insertQuery = "UPDATE user_data_m SET ideal_id=@ideal_id WHERE id=@curID;";
            else if (currentUserGender == "여자")
                insertQuery = "UPDATE user_data_f SET ideal_id=@ideal_id WHERE id=@curID;";

            connection.Open();

            command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@curID", currentUserId);
                command.Parameters.AddWithValue("@ideal_id", new_ideals);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
        }
       
    }
}
