using System;
using System.IO;
using System.Net.Sockets;

namespace FuncionSerClie
{
    public class SendTcp
    {
        byte[] data = new byte[1024];
        private const int BufferSize = 1024;


        public void sendMessage(string mensajeOrPath, string ip, int port)
        {
            //objects
            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            if (port == 8733)
            {
                data = System.Text.Encoding.ASCII.GetBytes(mensajeOrPath);
                stream.Write(data, 0, data.Length);
            }
            else
            {
                sendZip(mensajeOrPath, stream);
            }
            client.Close();
            stream.Close();
        }
        public void sendZip(string path, NetworkStream netstream)
        {
            byte[] SendingBuffer = null;
            byte[] RecData = new byte[BufferSize];
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fs.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)fs.Length, CurrentPacketLength;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;
                    SendingBuffer = new byte[CurrentPacketLength];
                    fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    fs.Flush();
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //// Close everything.
                fs.Close();
                netstream.Close();
            }
        }
    }
}
