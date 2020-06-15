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
    class handleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> clientList = null;

        public void startClient(TcpClient clientSocket, Dictionary<TcpClient, string> clientList)
        {
            this.clientSocket = clientSocket;
            this.clientList = clientList;

            Thread c_handler = new Thread(Chat);
            c_handler.IsBackground = true;
            c_handler.Start();
        }

        public delegate void MessageDisplayHandler(string message, string name);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;

        private void Chat()
        {
            NetworkStream stream = null;

            try
            {
                byte[] buffer = new byte[1024];
                string msg = string.Empty;
                int bytes = 0;

                while(true)
                {
                    stream = clientSocket.GetStream();
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    msg = msg.Substring(0, msg.IndexOf("$"));

                    if (OnReceived != null)
                        OnReceived(msg, clientList[clientSocket].ToString());
                }
            }

            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("Chat - SocketException {0}", se.Message));

                if(clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(string.Format("Chat - Exception : {0}", e.Message));

                if(clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
        }
    }
}
