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

namespace KW_Project_Chat_Server
{
    public partial class ChatServerForm : Form
    {
        TcpListener server = null;
        TcpClient clientSocket = null;


        private int PORT = 7777;

        //Random ran = new Random();
        //PORT = ran.Next(10000, 20000);
        //    MessageBox.Show(PORT.ToString());

        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();
        public ChatServerForm()
        {
            InitializeComponent();
        
        }

        //public int getPORT()
        //{
        //    return PORT;
        //}

        private void InitSocket()
        {
            

            server = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
            clientSocket = default(TcpClient);
            server.Start();
            Message("채팅방 생성");

            while(true)
            {
                try
                {
                    clientSocket = server.AcceptTcpClient();

                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string name = Encoding.Unicode.GetString(buffer, 0, bytes);
                    name = name.Substring(0, name.IndexOf("$"));

                    clientList.Add(clientSocket, name);

                    Message(name + "님께서 입장하셨습니다.");
                    SendMessageAll(name + "님께서 입장하셨습니다.", "" , false);

                    handleClient h_client = new handleClient();
                    h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                    h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                    h_client.startClient(clientSocket, clientList);
                }
                catch (SocketException se) { break; }

                catch(Exception e) { break; }
            }
            clientSocket.Close();
            server.Stop();
        }

        void h_client_OnDisconnected(TcpClient clientSocket)
        {
            if (clientList.ContainsKey(clientSocket))
                clientList.Remove(clientSocket);
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

        private void OnReceived(string message, string name)
        {
            if(message.Equals("채팅방을 나갑니다."))
            {
                Message(name + "님께서 채팅방을 나갔습니다.");
                SendMessageAll(name + "님께서 채팅방을 나갔습니다.", "", false);
            }

            else
            {
                Message(name + " : " + message);
                SendMessageAll(message, name, true);
            }
        }

        public void SendMessageAll(string message, string name, bool flag)
        {
            foreach(var pair in clientList)
            {
                Trace.WriteLine(string.Format("tcpclient : {0} name : {1}", pair.Key, pair.Value));

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                if(flag)
                {
                    buffer = Encoding.Unicode.GetBytes(name + " : " + message);
                }
                else
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if(txt_send.Text != null)
            {
                string message = "server : " + txt_send.Text;
                Message(message);
                SendMessageAll(message, "", false);

                txt_send.Text = "";
            }
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            if(btn_server.Text == "서버 시작")
            {
                Thread s_thread = new Thread(InitSocket);
                s_thread.IsBackground = true;
                s_thread.Start();

                btn_server.Text = "서버 종료";
            }

            else
            {
                server.Stop();
            }
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_send_Click(this, e);
        }


    }
}
