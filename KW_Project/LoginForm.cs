using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KW_Project
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
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
        }
    }
}
