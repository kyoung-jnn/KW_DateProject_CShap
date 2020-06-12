using System;
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
    public partial class RegisterForm : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=100984");
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRegisterConfirm_Click(object sender, EventArgs e)
        {
            if(R_txtId.Text == "")
            {
                MessageBox.Show("학번을 입력하세요!");
                R_txtId.Focus();
                return;
            }
            else if(R_txtPwd1.Text == "" || R_txtPwd2.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하세요!");
                R_txtPwd1.Focus();
                return;
            }

            if(R_txtPwd1.Text != R_txtPwd2.Text)
            {
                MessageBox.Show("비밀번호가 다릅니다.");
                R_txtPwd1.Focus();
                return;
            }
            else
            {
                MessageBox.Show("쿼리문 실행"); // 나중에 없앨거임

                // 학번, 비밀번호 전송
                string insertQuery = "INSERT INTO user_data(id,pwd) VALUES(" + R_txtId.Text + "," + R_txtPwd1.Text + ")";   

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                try
                {
                    if(command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("정상 전송");
                    }
                    else
                    {
                        MessageBox.Show("비정상 전송");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
        }
    }
}
