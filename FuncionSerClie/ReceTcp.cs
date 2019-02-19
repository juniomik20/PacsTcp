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


        public void connecTcpPort(int port)
        {
            TcpListener Listener = null;
            try
            {

                Listener = new TcpListener(IPAddress.Any, port);
                Listener.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TcpClient client = null;
            NetworkStream stream = null;
            bool clientTcp = false;
            while (!clientTcp)
            {
                try
                {
                    if (Listener.Pending())
                    {
                        clientTcp = true;
                        client = Listener.AcceptTcpClient();
                        byte[] bytes = new byte[1024];
<<<<<<< refs/remotes/origin/morata
                        NetworkStream stream = client.GetStream();
=======
                        stream = client.GetStream();
>>>>>>> send Zip
                        if (port == 8733)
                        {
                            Int32 ReadBytes = stream.Read(bytes, 0, bytes.Length);
                            _Message = System.Text.Encoding.ASCII.GetString(bytes, 0, ReadBytes);
                        }
<<<<<<< refs/remotes/origin/morata
                        else {

                            receZip();
                        }
                        stream.Close();
                        client.Close();
=======
                        else
                        {

                        }
>>>>>>> send Zip
                    }
                }
                catch (Exception ex)
                {
                    _Message = ex.Message;
                }
                finally
                {
                    clientTcp = false;
                    stream.Close();
                    client.Close();

                }
            }
        }
        public void receZip() {

        
        }
    }
}
