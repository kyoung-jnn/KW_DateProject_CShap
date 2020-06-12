﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; // Mysql 사용

namespace KW_Project
{
    public partial class loginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("입력 정보를 확인하세요!");
                return;
            }

            try
            {
                connection.Open();
                // 현재 입력한 학번으로 Mysql에서 가져옴
                string ReadQuery = "SELECT * FROM user_data_m where id = " + txtId.Text; 
                
                MySqlCommand cmd = new MySqlCommand(ReadQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                if (table.Read())
                {
                    if (txtId.Text == table["id"].ToString() && txtPwd.Text == table["pwd"].ToString())
                    {
                        this.Visible = false; // 로그인 창 닫아놓기
                        string userFlag = table["userFlag"].ToString();

                        // 기존 회원
                        if (userFlag == "1") 
                        {
                            // 로딩 창
                            LoadingForm loadingform = new LoadingForm();
                            DialogResult result = loadingform.ShowDialog();

                            if (result == DialogResult.Cancel)
                            {
                                MainMenuForm mainform = new MainMenuForm(table["id"].ToString(), table["gender"].ToString()); 
                                mainform.Show();
                            }
                        }
                        // 신규 회원
                        else
                        {
                            FirstSettingForm settingform = new FirstSettingForm(txtId.Text);
                            DialogResult result = settingform.ShowDialog();

                            if (result == DialogResult.Cancel)
                            {
                                this.Visible = true;
                            }
                            else if (result == DialogResult.No)
                            {
                                //this.Close();          

                            }
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
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false; // 로그인 창 닫아놓기

            RegisterForm registerform = new RegisterForm();
            DialogResult result = registerform.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
            else if (result == DialogResult.No) // form을 아예 종료
            {
                this.Close();

            }
        }
    }
}
