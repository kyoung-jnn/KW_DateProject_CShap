namespace KW_Project_Chat_Server
{
    partial class ChatServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_display = new System.Windows.Forms.TextBox();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_server = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_display
            // 
            this.txt_display.Location = new System.Drawing.Point(30, 12);
            this.txt_display.Multiline = true;
            this.txt_display.Name = "txt_display";
            this.txt_display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_display.Size = new System.Drawing.Size(442, 312);
            this.txt_display.TabIndex = 0;
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(30, 388);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(442, 25);
            this.txt_send.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(535, 379);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(114, 39);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "보내기";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            this.btn_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_send_KeyDown);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(567, 150);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 25);
            this.txt_port.TabIndex = 3;
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(567, 99);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 25);
            this.txt_ip.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(535, 242);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(119, 41);
            this.btn_server.TabIndex = 7;
            this.btn_server.Text = "서버 시작";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.btn_server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_display);
            this.Name = "ChatServer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_display;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_server;
    }
}

