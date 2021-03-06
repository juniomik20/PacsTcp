﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NaveEspacial
{
    public partial class ShipForm : Form
    {
        FuncionClass.SendTcp sendTcp = new FuncionClass.SendTcp();
        FuncionClass.ReceTcp receTcp = new FuncionClass.ReceTcp();
        ConnectionClass.ConnectBDD connectBDD = new ConnectionClass.ConnectBDD();
        Proyecto2Main.Proyecto2Main unZipClass = new Proyecto2Main.Proyecto2Main();
        DesgenerarFitxers.FrmDesxifasio desxifasio = new DesgenerarFitxers.FrmDesxifasio();
        Thread ServerShipMessage;
        Thread ServerShipFiles;
        Thread descifrarTheard;
        Thread shipThread;
        Thread unZipThread;
        Thread enviarThread;
        Thread abortThread;


        string pathUnzip = Application.StartupPath + @"\Fitxers\Descifrar\PACS.zip";
        string pathSend = Application.StartupPath + @"\Fitxers\Descifrar\PacsSol.txt";
        public ShipForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            sendTcp.sendMessage(identifiMessage(), "172.17.20.74", 8733);

            addLog("Ship: Connect to planet");
        }


        public string identifiMessage()
        {
            string message = null;
            DataSet dts = connectBDD.PortaTaula("DeliveryData");
            string CodeDelivery = dts.Tables[0].Rows[0]["CodeDelivery"].ToString();
            string DeliveryDate = dts.Tables[0].Rows[0]["DeliveryDate"].ToString();
            string SpaceShip = dts.Tables[0].Rows[0]["SpaceShip"].ToString();
            string[] dayMessage = DeliveryDate.Split('/');
            string day = dayMessage[0];
            string month = dayMessage[1];
            string yearSplit = dayMessage[2];
            string[] hour = yearSplit.Split(' ');
            string year = hour[0];
            message = month + day + year + SpaceShip + CodeDelivery;
            return message;
        }

        private void ShipForm_Load(object sender, EventArgs e)
        {

            ServerShipMessage = new Thread(() => receTcp.connecTcpPort(8733, pathUnzip));
            ServerShipMessage.SetApartmentState(ApartmentState.STA);
            ServerShipMessage.Start();
            ServerShipFiles = new Thread(() => receTcp.connecTcpPort(5000, pathUnzip));
            ServerShipFiles.SetApartmentState(ApartmentState.STA);
            shipThread = new Thread(ship);
            unZipThread = new Thread(unZip);
            enviarThread = new Thread(enviarArxiu);
            descifrarTheard = new Thread(descifrarArxius);
            abortThread = new Thread(abortTime);
            ServerShipFiles.Start();
            shipThread.Start();
        }

        void ship()
        {
            while (true)
            {
                if (receTcp.messageReady == true)
                {
                    if (logBoxShip.InvokeRequired)
                    {
                        logBoxShip.Invoke((MethodInvoker)delegate { addLog("Planet: " + receTcp.varMensajeClient); });
                    }
                    else
                    {
                        addLog("Planet: " + receTcp.varMensajeClient);
                    }
                    if (receTcp.varMensajeClient.Contains("Zip"))
                    {
                        if (cuentaAtras1.InvokeRequired)
                        {
                            cuentaAtras1.Invoke((MethodInvoker)delegate
                            {
                                cuentaAtras1.onTimer();
                            });
                        }
                        else
                        {
                            cuentaAtras1.onTimer();
                        }
                        abortThread.Start();
                        try
                        {
                            unZipThread.Start();
                            unZipThread.Join();
                            descifrarTheard.Start();
                            descifrarTheard.Join();
                            enviarThread.Start();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    else if(receTcp.varMensajeClient.Contains("cubo")) {
                        if (explosionShip.InvokeRequired)
                        {
                            explosionShip.Invoke((MethodInvoker)delegate { explosionShip.Visible = true;
                                cuentaAtras1.timeOut = true;


                            });
                        }
                        else
                        {
                            explosionShip.Visible = true;
                            cuentaAtras1.timeOut = true;
                        }



                    }
                    receTcp.messageReady = false;
                }
            }
        }
        void unZip()
        {
            unZipClass.Descomprimir();
        }

        void descifrarArxius()
        {
            desxifasio.crearFitxers();
            if (logBoxShip.InvokeRequired)
            {
                logBoxShip.Invoke((MethodInvoker)delegate { addLog("Planet: archivos descomprimidos"); });
            }
            else
            {
                addLog("Planet: archivos descomprimidos");
            }
        }

        void enviarArxiu()
        {
            sendTcp.sendMessage(pathSend, "172.17.20.74", 5000);
            if (logBoxShip.InvokeRequired)
            {
                logBoxShip.Invoke((MethodInvoker)delegate { addLog("Planet: archivo enviado"); });
            }
            else
            {
                addLog("Planet: archivo enviado");
            }
            sendTcp.sendMessage("PacSol enviado", "172.17.20.74", 8733);


            if (cuentaAtras1.InvokeRequired)
            {
                cuentaAtras1.Invoke((MethodInvoker)delegate
                {
                    cuentaAtras1.offTimer();
                });
            }
            else
            {
                cuentaAtras1.offTimer();
            }
            abortThread.Abort();
        }

        public void addLog(string message)
        {
            logBoxShip.AppendText(DateTime.Now.ToString("HH:mm: ") + message + "\n");
        }

        public void abortTime()
        {
            while (true)
            {
                if (cuentaAtras1.timeOut)
                {
                    unZipThread.Abort();
                    descifrarTheard.Abort();
                    enviarThread.Abort();
                    abortThread.Abort();
                    shipThread.Abort();
                    ServerShipFiles.Abort();
                    ServerShipMessage.Abort();
                }

            }

        }


    }
}
