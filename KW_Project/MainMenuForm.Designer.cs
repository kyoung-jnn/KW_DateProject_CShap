namespace KW_Project
{
    partial class MainMenuForm
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
            this.btnHome = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.idealPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.idealPic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14F);
            this.btnHome.Location = new System.Drawing.Point(12, 573);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(115, 72);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "홈";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChat.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14F);
            this.btnChat.Location = new System.Drawing.Point(141, 573);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(115, 72);
            this.btnChat.TabIndex = 1;
            this.btnChat.Text = "채팅";
            this.btnChat.UseVisualStyleBackColor = false;
            // 
            // btnBoard
            // 
            this.btnBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoard.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14F);
            this.btnBoard.Location = new System.Drawing.Point(271, 573);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(115, 72);
            this.btnBoard.TabIndex = 2;
            this.btnBoard.Text = "게시판";
            this.btnBoard.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProfile.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14F);
            this.btnProfile.Location = new System.Drawing.Point(399, 573);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(115, 72);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "프로필";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10F);
            this.btnExit.Location = new System.Drawing.Point(477, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // idealPic
            // 
            this.idealPic.Location = new System.Drawing.Point(84, 39);
            this.idealPic.Name = "idealPic";
            this.idealPic.Size = new System.Drawing.Size(360, 344);
            this.idealPic.TabIndex = 5;
            this.idealPic.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 657);
            this.Controls.Add(this.idealPic);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnBoard);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idealPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnBoard;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox idealPic;
    }
}