namespace KW_Project
{
    partial class FirstSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.departmentList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.circleButton1 = new KW_Project.CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.MistyRose;
            this.label2.Location = new System.Drawing.Point(136, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "학과를 선택하세요";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 601);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "지적임";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.MistyRose;
            this.label1.Location = new System.Drawing.Point(123, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "취미 혹은 장점이 무엇인가요?";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(141, 662);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 36);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "뒤로가기";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(243, 662);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 36);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "다음";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // departmentList
            // 
            this.departmentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentList.FormattingEnabled = true;
            this.departmentList.Items.AddRange(new object[] {
            "소프트웨어학부",
            "컴퓨터공학부",
            "정보융합학부"});
            this.departmentList.Location = new System.Drawing.Point(141, 502);
            this.departmentList.Name = "departmentList";
            this.departmentList.Size = new System.Drawing.Size(150, 23);
            this.departmentList.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.MistyRose;
            this.label4.Location = new System.Drawing.Point(75, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "이름과 성별을 입력하세요";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 409);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 25);
            this.txtName.TabIndex = 16;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "남자",
            "여자"});
            this.comboBox2.Location = new System.Drawing.Point(234, 409);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(74, 23);
            this.comboBox2.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 36);
            this.button2.TabIndex = 18;
            this.button2.Text = "섹시함";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 601);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 36);
            this.button3.TabIndex = 19;
            this.button3.Text = "멍청함";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(80, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 204);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(51, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "프로필 사진";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Image = global::KW_Project.Properties.Resources.heart;
            this.button4.Location = new System.Drawing.Point(155, 262);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 30);
            this.button4.TabIndex = 22;
            this.button4.Text = "사진 등록/수정";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // circleButton1
            // 
            this.circleButton1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.circleButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.circleButton1.Image = global::KW_Project.Properties.Resources.heart;
            this.circleButton1.Location = new System.Drawing.Point(294, 260);
            this.circleButton1.Name = "circleButton1";
            this.circleButton1.Size = new System.Drawing.Size(61, 32);
            this.circleButton1.TabIndex = 23;
            this.circleButton1.Text = "Upload";
            this.circleButton1.UseVisualStyleBackColor = true;
            this.circleButton1.Click += new System.EventHandler(this.CircleButton1_Click);
            // 
            // FirstSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(81)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(477, 722);
            this.Controls.Add(this.circleButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.departmentList);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirstSettingForm";
            this.Text = "FirstSettingForm";
            this.Load += new System.EventHandler(this.FirstSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox departmentList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private CircleButton circleButton1;
    }
}