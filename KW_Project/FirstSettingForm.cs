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

namespace KW_Project
{
    public partial class FirstSettingForm : Form
    {
        private string currentUserId;
        public FirstSettingForm(string id)
        {
            currentUserId = id;
            InitializeComponent();
        }


        private void FirstSettingForm_Load(object sender, EventArgs e)
        {
            // 테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false; // 첫번째 세팅창 받기

            SecondSetting settingform = new SecondSetting(currentUserId);
            DialogResult result = settingform.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }
    }
    
}
