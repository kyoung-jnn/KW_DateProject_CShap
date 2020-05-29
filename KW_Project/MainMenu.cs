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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //프로필 등록(수정) 버튼
        private void Button1_Click(object sender, EventArgs e)
        {
            // 여기서 메뉴창 열기
            FirstSettingForm settingform = new FirstSettingForm();
             DialogResult result = settingform.ShowDialog();
        }
    }
}
