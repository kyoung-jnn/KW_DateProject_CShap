using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public NetworkStream m_Stream;  // 네트워크 스트림
        public StreamReader m_Read;     // 읽기
        public StreamWriter m_Write;    // 쓰기

        public bool m_bConnect = false; // 서버 접속 플래그

        private Thread m_ThReader;      // 읽기 스레드
        private TcpClient m_Client;

        public int Port;                // 포트번호

        public Form1()
        {
            InitializeComponent();
        }

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txt_all.AppendText(msg + "\r\n");
                txt_all.Focus();
                txt_all.ScrollToCaret();
                txt_send.Focus();
            }));
        }

        public void serverConnect()
        {
            try
            {
                Port = Convert.ToInt32(txt_serverPort.Text);

                m_Client = new TcpClient();

                try
                {
                    m_Client.Connect(txt_serverIP.Text, Port);
                }
                catch
                {
                    m_bConnect = false;
                    return;
                }
                m_bConnect = true;
                Message("연결을 시작합니다.");

                m_Stream = m_Client.GetStream();

                m_Read = new StreamReader(m_Stream);
                m_Write = new StreamWriter(m_Stream);
                //닉네임 전송
                m_Write.WriteLine(txt_nickName.Text);
                m_Write.Flush();

                m_ThReader = new Thread(new ThreadStart(Receive));
                m_ThReader.Start();
            }
            catch(Exception e)
            {
                Message("서버 연결 실패");
            }
            
        }

        public void serverDisconnect()
        {
            if (!m_bConnect)
                return;
            
            // 종료 메세지 전송
            m_Write.WriteLine("EXIT|" + txt_nickName.Text);
            m_Write.Flush();

            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();

            m_ThReader.Abort();
            
            Message("연결을 해제합니다.");
        }
        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    string receiveMessage = m_Read.ReadLine();

                    if (receiveMessage != null)
                    {
                        int breakPoint = receiveMessage.IndexOf("|");
                        string newMessage = receiveMessage.Substring(0, breakPoint);
                        string NickName = receiveMessage.Substring(breakPoint + 1);

                        Message(NickName + " : " + newMessage);
                    }
                        
                }
            }
            catch(ThreadAbortException) { 
            }
            catch(Exception e)
            {
                Message("메세지 수신 실패");
            }
        }

        public void Send()
        {
            try
            {
                m_Write.WriteLine(txt_send.Text+ "|" +txt_nickName.Text);
                m_Write.Flush(); // 메시지 보내기

                Message(txt_nickName.Text + " : " + txt_send.Text);
                txt_send.Text = "";
            }
            catch
            {
                Message("메시지 전송 실패");
            }
        }

        private void btn_serverConnect_Click(object sender, EventArgs e)
        {
            if(btn_serverConnect.Text == "서버 연결")
            {
                serverConnect();
                btn_serverConnect.Text = "서버 연결 종료";
                btn_serverConnect.ForeColor = Color.Red;
            }
            else
            {
                serverDisconnect();
                btn_serverConnect.Text = "서버 연결";
                btn_serverConnect.ForeColor = Color.Black;
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverDisconnect();
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_all.Text = "";
        }
    }
}
