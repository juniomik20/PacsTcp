using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FuncionSerClie
{
    public class ReceTcp
    {

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }


        public void connecTcpPort(string ip, int port)
        {
            TcpListener Listener = null;
            try
            {

                IPAddress localAddr = IPAddress.Parse(ip);
                Listener = new TcpListener(localAddr, port);
                Listener.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TcpClient client = null;
            while (true)
            {

                try
                {
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        string data;
                        byte[] bytes = new byte[1024];
                        data = null;
                        NetworkStream stream = client.GetStream();
                        data = string.Empty;
                        if (port == 5000)
                        {
                            Int32 ReadBytes = stream.Read(bytes, 0, bytes.Length);
                            _Message = System.Text.Encoding.ASCII.GetString(bytes, 0, ReadBytes);
                        }

                        stream.Close();
                        client.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    _Message = ex.Message;
                }
                finally{
                    
                }
            }
           


        }
    }
}
