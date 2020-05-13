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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        public NetworkStream m_Stream;  // 네트워크 스트림
        public NetworkStream newStream; // Send() 에서 모두에게 보내는 스트림
        public StreamReader m_Read;     // 읽기
        public StreamWriter m_Write;    // 쓰기

        public bool m_bStop = false;    // 서버 시작 & 중단 플래그
        public bool m_bConnect = false; // 서버 접속 플래그

        private TcpListener m_listener; // 서버 작동 리스너
        private Thread m_ThServer;      // 서버 스레드
        private Thread m_ThReader;      // 읽기 스레드

        public int Port;                // 포트번호
        public string m_nickName;   // 서버에 접속한 client 닉네임

        // Dictionnary를 이용하여 Pair로 cilent를 저장
        public Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();

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

        public void serverStart()
        {
            try
            {
                Port = Convert.ToInt32(txt_serverPort.Text);

                m_listener = new TcpListener(Port);
                m_listener.Start(); // 서버 작동!

                m_bStop = true;
                Message("서버 실행 성공, 클라이언트 연결 대기중");

                while (m_bStop)
                {
                    TcpClient hClient = m_listener.AcceptTcpClient();

                    if (hClient.Connected)
                    {
                        m_bConnect = true;

                        m_Stream = hClient.GetStream();
                        m_Read = new StreamReader(m_Stream);

                        // client 닉네임 받아오기
                        m_nickName = m_Read.ReadLine();
                        Send(m_nickName + " 님께서 접속하셨습니다.", "System", true);
                        clientList.Add(m_nickName, hClient); // 리스트에 추가

                        m_ThReader = new Thread(new ThreadStart(Receive)); // 읽기 스레드
                        m_ThReader.Start();
                    }
                }

            }
            catch (SocketException) { 
            }
            catch (Exception e)
            {
                Message("서버 실행 실패");
            }
        }

        public void serverStop()
        {
            Message("서버 종료");

            try
            {
                foreach (var name in clientList.Keys.ToList())
                {
                    clientList.Remove(name); // 서버를 먼저 끌 경우
                }

                if (!m_bStop)
                    return;

                m_listener.Stop();

                m_bStop = false;
                m_bConnect = false;

                m_Read.Close();
                m_Write.Close();
                m_Stream.Close();
                
                m_ThReader.Abort();
                m_ThServer.Abort();

            }
            catch (NullReferenceException)
            {
                // stream & thread 가 null일 경우 예외처리를 발생시켜서 추가
            }
            
        }

        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    string receiveMsg = m_Read.ReadLine();
                    
                    int breakPoint = receiveMsg.IndexOf("|"); // 문자 '|'를 기준으로 나눔
                    string newMsg = receiveMsg.Substring(0, breakPoint);
                    string newNickname = receiveMsg.Substring(breakPoint + 1);

                    // 현재 메세지를 보낸 client 찾기
                    foreach (var name in clientList.Keys)
                    {
                        if (name == newNickname) 
                        {
                            TcpClient savedClient = clientList[name]; // 리스트에 저장된 client 불러오기
                            m_Stream = savedClient.GetStream();
                            m_Read = new StreamReader(m_Stream); // 새로운 읽기 stream 지정
                        }
                    }

                    if (newMsg == "EXIT") //종료 메세지
                    {
                        // 종료한 client를 clientList에서 삭제
                        foreach (var name in clientList.Keys.ToList())
                        {
                            if (name == newNickname)
                                clientList.Remove(name);
                        }
                        Send(newNickname + " 님께서 종료하셨습니다.", "System", true);
                    }
                    else
                    {
                        Message(newNickname + " : " + newMsg);
                        Send(newMsg, newNickname, false);
                    }
                }
            }
            catch(NullReferenceException) {
            }
            catch (IOException) {
            }
            catch(Exception e)
            {
                Message(e.ToString());
                Message("메세지 수신 실패");
            }
        }

        // 서버의 Send 메소드는 모두에게 메시지를 뿌려줘야함
        public void Send(string message, string nickname, bool serverFlag)
        {
            try
            {
                foreach (var name in clientList.Keys)
                {
                    if (nickname != name)
                    {
                        TcpClient savedClient = clientList[name]; // 리스트에 저장된 client 불러오기
                        m_Stream = savedClient.GetStream();
                        m_Write = new StreamWriter(m_Stream); // 새로운 쓰기 stream 생성

                        m_Write.WriteLine(message + "|" + nickname);
                        m_Write.Flush();
                    }
                }

                if (serverFlag == true) // Server & System 에서 보낸것
                {
                    if (nickname == "System")
                        Message(nickname + " : " + message); // 접속 & 종료 메시지
                    else
                    {
                        Message("Server : " + message);
                        txt_send.Text = "";
                    }
                }
            }
            catch(Exception e)
            {
                Message("메세지 전송 실패");
            }
        }

        private void btn_serverStart_Click(object sender, EventArgs e)
        {
            if (btn_serverStart.Text == "서버 시작")
            {
                m_ThServer = new Thread(new ThreadStart(serverStart)); // 서버 스레드
                m_ThServer.Start();


                btn_serverStart.Text = "서버 멈춤";
                btn_serverStart.ForeColor = Color.Red;
            }
            else
            {
                serverStop();
                btn_serverStart.Text = "서버 시작";
                btn_serverStart.ForeColor = Color.Black;
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Send(txt_send.Text, "Server", true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverStop();
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send(txt_send.Text, "Server", true);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_all.Text = "";
        }
    }
}
