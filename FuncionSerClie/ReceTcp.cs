﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;


namespace FuncionSerClie
{
    public class ReceTcp
    {
        private const int BufferSize = 2048;
        byte[] RecData = new byte[BufferSize];
        int RecBytes;        

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
                        stream = client.GetStream();
                        if (port == 8733)
                        {
                            Int32 ReadBytes = stream.Read(bytes, 0, bytes.Length);
                            _Message = System.Text.Encoding.ASCII.GetString(bytes, 0, ReadBytes);
                        }
                        else {

                            receZip(client,);
                        }
                       
                        

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
        public void receZip(TcpClient client)
        {
            //borrarArchivos();
            string SaveFileName = Application.StartupPath + @"\Fitxers\Dessifra\PACS.zip";
            int totalrecbytes = 0;
            FileStream Fs = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
            if (Fs.CanWrite)
            {
                while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                {
                    Fs.Write(RecData, 0, RecBytes);
                    totalrecbytes += RecBytes;
                    Fs.Flush();
                }
            }
        }
    }
}
