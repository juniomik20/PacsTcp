using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FuncionClass
{
    public class ReceTcp
    {
        private const int BufferSize = 2048;
        byte[] RecData = new byte[BufferSize];
        int RecBytes;
        public bool messageReady;
        public bool clientTcp = false;
        private string _Message;

        public string varMensajeClient
        {
            get { return _Message; }
            set { _Message = value; }
        }


        public void connecTcpPort(int port, string path)
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



            while (true)
            {
                TcpClient client = null;
                NetworkStream stream = null;
                try
                {
                    if (Listener.Pending())
                    {
                        clientTcp = true;
                        client = Listener.AcceptTcpClient();
                        byte[] bytes = new byte[1024];
                        stream = client.GetStream();
                        if (stream != null)
                        {
                            if (port == 8733)
                            {
                                string cadena;
                                Int32 ReadBytes = stream.Read(bytes, 0, bytes.Length);

                                cadena = System.Text.Encoding.ASCII.GetString(bytes, 0, ReadBytes);
                                varMensajeClient = cadena;
                                messageReady = true;
                            }
                            else if (port == 5000)
                            {
                                receZip(client, stream, path);
                            }
                        }



                    }

                    stream.Close();
                    client.Close();


                }
                catch (Exception ex)
                {
                }
                finally
                {


                }
            }
        }
        private void receZip(TcpClient client, NetworkStream netstream, string path)
        {
            //borrarArchivos();
            int totalrecbytes = 0;
            FileStream Fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            if (Fs.CanWrite)
            {
                while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                {
                    Fs.Write(RecData, 0, RecBytes);
                    totalrecbytes += RecBytes;
                    Fs.Flush();
                }
                netstream.Close();
                Fs.Close();
            }

        }
    }
}
