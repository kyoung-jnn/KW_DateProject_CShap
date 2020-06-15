using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Net;
using KW_Project_Chat_Server;

namespace KW_Project
{
    public partial class ChatClientForm : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;
        private int PORT = 12345;
        
        public ChatClientForm()
        {
            InitializeComponent();
        }

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txt_display.AppendText(msg + "\r\n");
                txt_display.Focus();
                txt_display.ScrollToCaret();
                txt_send.Focus();
            }));
        }

        private void btn_send_Click(object sender, EventArgs e) //메세지 보내기
        {
            byte[] buffer = Encoding.Unicode.GetBytes(txt_send.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            txt_send.Text = "";
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if(btn_connect.Text == "서버연결")
            {
                //ChatServerForm chatServer = new ChatServerForm();
                //int PORT = chatServer.getPORT();
                //MessageBox.Show(PORT.ToString());

                clientSocket.Connect(IPAddress.Parse("127.0.0.1"), PORT);
                stream = clientSocket.GetStream();

                Message("상대방의 채팅방 입장 대기중");

                byte[] buffer = Encoding.Unicode.GetBytes(txt_name.Text + "$"); // 이름정보를 서버에 전송.
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                Thread m_thread = new Thread(GetMessage);
                m_thread.IsBackground = true;
                m_thread.Start();

                btn_connect.Text = "연결 끊기";

            }

            else
            {
                Message("채팅방을 나갑니다.");
                //채팅방을 나간것을 서버에 알림.
                byte[] buffer = Encoding.Unicode.GetBytes("채팅방을 나갑니다.$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                btn_connect.Text = "서버 연결";

                clientSocket.Close();
            }
        }

        private void GetMessage() //메시지를 받아와서 읽기.
        {
            while(true)
            {
                stream = clientSocket.GetStream();
                int buffer_size = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[buffer_size];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                Message(message);
            }
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_send_Click(this, e);
        }
    }
}
