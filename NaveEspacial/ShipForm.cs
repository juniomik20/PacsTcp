using System;
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


        string pathUnzip = Application.StartupPath + @"\Fitxers\Descifrar\PACS.zip";
        string pathSend = Application.StartupPath + @"\Fitxers\Descifrar\PacsSol.txt";
        public ShipForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            sendTcp.sendMessage(identifiMessage(), "172.17.20.157", 8733);
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

            descifrarTheard = new Thread(descifrarArxius);
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
                        unZipThread.Start();
                    }
                    receTcp.messageReady = false;
                }
            }
        }
        void unZip() {
            unZipClass.Descomprimir();
            descifrarTheard.Start();
        }

        void descifrarArxius()
        {
            unZipThread.Join();
            desxifasio.crearFitxers();
            if (logBoxShip.InvokeRequired)
            {
                logBoxShip.Invoke((MethodInvoker)delegate { addLog("Planet: archivos descomprimidos"); });
            }
            else
            {
                addLog("Planet: archivos descomprimidos");
            }
            enviarArxiu();
        }

        void enviarArxiu() {
            descifrarTheard.Join();
            sendTcp.sendMessage(pathSend, "172.17.20.157", 5000);
            if (logBoxShip.InvokeRequired)
            {
                logBoxShip.Invoke((MethodInvoker)delegate { addLog("Planet: archivo enviado"); });
            }
            else
            {
                addLog("Planet: archivo enviado");
            }
        }

        public void addLog(string message)
        {
            logBoxShip.AppendText(DateTime.Now.ToString("HH:mm: ") + message + "\n");
        }


    }
}
