using System;
using System.Net.Sockets;

namespace FuncionSerClie
{
    public class SendTcp
    {
        Byte[] data = new Byte[1024];


        public void sendMessage(string mensajeOrPath,string ip, int port) {

            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();

            if (true)
            {

            }
            data = System.Text.Encoding.ASCII.GetBytes(mensajeOrPath);
            stream.Write(data, 0, data.Length);
        }
        public void sendZip(string path) {

            




        }



    }
}
