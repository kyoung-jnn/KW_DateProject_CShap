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
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(12, 478);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(115, 72);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "홈";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(141, 478);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(115, 72);
            this.btnChat.TabIndex = 1;
            this.btnChat.Text = "채팅";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnBoard
            // 
            this.btnBoard.Location = new System.Drawing.Point(271, 478);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(115, 72);
            this.btnBoard.TabIndex = 2;
            this.btnBoard.Text = "게시판";
            this.btnBoard.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(399, 478);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(115, 72);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "프로필";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 562);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnBoard);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnHome);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenuForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnBoard;
        private System.Windows.Forms.Button btnProfile;
    }
}