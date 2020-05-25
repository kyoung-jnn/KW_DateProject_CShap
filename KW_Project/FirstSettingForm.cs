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
using MySql.Data.MySqlClient;

namespace KW_Project
{
    public partial class FirstSettingForm : Form
    {
        private string currentUserId;
        string ID = null;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        DataSet ds;
        MySqlDataAdapter da;
        public FirstSettingForm(string id)
        {
            currentUserId = id;
            InitializeComponent();
            SetBtnEvent();
        }
        private void SetBtnEvent()
        {
            button1.Click += Btn_Click;
            button2.Click += Btn_Click;
            button3.Click += Btn_Click;
            button4.Click += Btn_Click;
            button5.Click += Btn_Click;
            button6.Click += Btn_Click;
            button7.Click += Btn_Click;
            button8.Click += Btn_Click;
            button9.Click += Btn_Click;
            button10.Click += Btn_Click;
            button11.Click += Btn_Click;
            button12.Click += Btn_Click;
            button13.Click += Btn_Click;
            button14.Click += Btn_Click;
            button15.Click += Btn_Click;
            button16.Click += Btn_Click;
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
            Button[] attlist = new Button[8];               //본인 성격 버튼 배열
            attlist[0] = button1;
            attlist[1] = button2;
            attlist[2] = button3;
            attlist[3] = button4;
            attlist[4] = button5;
            attlist[5] = button6;
            attlist[6] = button7;
            attlist[7] = button8;

            Button[] attlist2 = new Button[8];              //본인 매력포인트 버튼 배열
            attlist2[0] = button9;
            attlist2[1] = button10;
            attlist2[2] = button11;
            attlist2[3] = button12;
            attlist2[4] = button13;
            attlist2[5] = button14;
            attlist2[6] = button15;
            attlist2[7] = button16;

            if (!IsAttractSelected(attlist, attlist2))              //버튼이 3개씩 선택되지 않았을 경우 리턴
                return;
            MessageBox.Show("쿼리문 실행"); // 나중에 없앨거임

            // 이름, 성별, 학과, 본인어필, 이상형 전송
            string CheckId = "SELECT * FROM user_data WHERE id = " + ID;
            string insertQuery = "INSERT INTO user_data(name,gender,department,attraction) VALUES(" + txtName.Text + "," + cmbSex.SelectedItem.ToString() + "," + departmentList.SelectedItem.ToString() + "," +
                                                                                                            SelectedAttraction(attlist) + SelectedAttraction(attlist2) + ")";
            connection.Open();
            MySqlCommand command1 = new MySqlCommand(CheckId, connection);
            try
            {
                da = new MySqlDataAdapter(CheckId, connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "user_data");
                DataRow curRow = ds.Tables["id"].Rows.Find(ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("정상 전송");
                }
                else
                {
                    MessageBox.Show("비정상 전송");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            connection.Close();
            this.Visible = false; // 첫번째 세팅창 받기

            SecondSetting settingform = new SecondSetting(currentUserId);
            DialogResult result = settingform.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }
        private bool IsAttractSelected(Button[] btns1, Button[] btns2)        //성격, 매력 버튼이 각각 3개 선택되었는지 체크
        {
            Color selected = Color.PaleGreen;     //선택되었을때의 색깔
            int count1 = 0;
            for (int i = 0; i < btns1.Length; i++)
            {
                if (btns1[i].BackColor == selected)
                    count1++;
            }
            int count2 = 0;
            for (int i = 0; i < btns2.Length; i++)
            {
                if (btns2[i].BackColor == selected)
                    count2++;
            }
            if (count1 == 3 && count2 == 3)
                return true;
            else
            {
                string message = null;
                if (count1 != 3)
                    message += "성격 ";
                if (count2 != 3)
                    message += "매력 ";
                MessageBox.Show(message + "을 3개 선택해 주세요!");
                return false;
            }
        }
        private string SelectedAttraction(Button[] btns)           // 선택된 버튼들 string으로 반환
        {
            string ret = null;
            Color selected = Color.PaleGreen;               // 색 수정시 이부분 수정

            for (int i = 0; i < btns.Length; i++)
            {
                if (btns[i].BackColor == selected)
                    ret += btns[i].Text + "_";
            }
            return ret;
        }
        private void Btn_Click(object sender, EventArgs e)          //버튼들 공통 이벤트 처리
        {
            Color basic = Color.LightCoral;             //   -- 색 수정시 이부분 수정
            Color clicked = Color.PaleGreen;            //   ┘ 
            if ((sender as Button).BackColor.Equals(basic))
            {
                (sender as Button).BackColor = clicked;
                return;
            }
            if ((sender as Button).BackColor.Equals(clicked))
            {
                (sender as Button).BackColor = basic;
                return;
            }
        }
    }
    
}
