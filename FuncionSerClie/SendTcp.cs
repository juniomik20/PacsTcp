using System;
using System.Net.Sockets;

namespace FuncionSerClie
{
    public class SendTcp
    {
        Byte[] data = new Byte[1024];

        //Mensaje del cliente
        public void sendMessage(string mensajeOrPath,string ip, int port) {

            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            data = System.Text.Encoding.ASCII.GetBytes(mensajeOrPath);
            stream.Write(data, 0, data.Length);
            client.Close();
            stream.Close();

        }
        public void sendZip(string path) {


        }

    }
}
