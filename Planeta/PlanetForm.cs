using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Planeta
{
    public partial class PlanetForm : Form
    {
        ConnectionClass.ConnectBDD ConnectBDD = new ConnectionClass.ConnectBDD();
        string pathZip = Application.StartupPath + @"\Fitxers\PACS.zip";
        string path = Application.StartupPath + @"\Fitxers\";
        FuncionClass.ReceTcp receTcp = new FuncionClass.ReceTcp();
        FuncionClass.SendTcp sendTcp = new FuncionClass.SendTcp();
        GenerarFitxers.FrmXifrasio xifrasio = new GenerarFitxers.FrmXifrasio();
        TimerRebel.CuentaAtras cuentaAtras = new TimerRebel.CuentaAtras();
        Proyecto2Main.Proyecto2Main zipCompres = new Proyecto2Main.Proyecto2Main();
        Thread generarFitchersTheard;
        Thread generarZipTheard;
        Thread serverMensajeThread;
        Thread serverFilesThread;
        public PlanetForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            addLog("Planet: Iniciando el Servidor...");
            path = Application.StartupPath + @"\Fitxers\PacsSolShip.txt";


            generarFitchersTheard = new Thread(generarFicheros);
            generarZipTheard = new Thread(generarZip);

            serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733, path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            serverFilesThread = new Thread(() => receTcp.connecTcpPort(5000, path));
            serverFilesThread.SetApartmentState(ApartmentState.STA);
            Thread planetThread = new Thread(planet);


            serverMensajeThread.Start();
            serverFilesThread.Start();
            planetThread.Start();
        }



        void generarFicheros()
        {

            xifrasio.crearFitxers();

            generarZipTheard.Start();
        }

        void generarZip()
        {
            generarFitchersTheard.Join();

            if (logBoxPlanet.InvokeRequired)
            {
                logBoxPlanet.Invoke((MethodInvoker)delegate { addLog("Archivos generados"); });
            }
            else
            {
                addLog("Archivos generados");
            }


            zipCompres.Comprimir();
            generarZipTheard.Join();
            generarFitchersTheard.Abort();
            generarZipTheard.Abort();


        }



        public void addLog(string message)
        {
            logBoxPlanet.AppendText(DateTime.Now.ToString("HH:mm: ") + message + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            planet();
        }
        void planet()
        {
            while (true)
            {
<<<<<<< HEAD
            if (receTcp.messageReady==true)
            {
                addLog(receTcp.varMensajeClient);
                receTcp.messageReady = false;
                if (comprobarEntrada(receTcp.varMensajeClient))
                {   
=======
                if (receTcp.messageReady == true)
                {
                    if (logBoxPlanet.InvokeRequired)
                    {
                        logBoxPlanet.Invoke((MethodInvoker)delegate { addLog("Ship "+receTcp.varMensajeClient); });
                    }
                    else
                    {
                        addLog("Ship " + receTcp.varMensajeClient);
                    }
                    receTcp.messageReady = false;

                    if (comprobarEntrada(receTcp.varMensajeClient))
                    {
>>>>>>> master
                        if (logBoxPlanet.InvokeRequired)
                        {
                            logBoxPlanet.Invoke((MethodInvoker)delegate { addLog("Planet: Entrada confirmada"); });
                        }
                        else
                        {
                            addLog("Planet: Entrada confirmada");
                        }


                        sendTcp.sendMessage("Entrada Confirmada", "172.17.20.204", 8733);

                        sendTcp.sendMessage(pathZip, "172.17.20.204", 5000);

                        if (logBoxPlanet.InvokeRequired)
                        {
                            logBoxPlanet.Invoke((MethodInvoker)delegate { addLog("Planet: Zip Enviado"); });
                        }
                        else
                        {
                            addLog("Planet: Zip Enviado");
                        }
                        sendTcp.sendMessage("Zip enviado", "172.17.20.204", 8733);



                    }
                    else
                    {
                        sendTcp.sendMessage("Entrada denegada cabeza cubo", "172.17.20.204", 8733);

                    }

                }
            }
        }
        bool comprobarEntrada(string message)
        {

            string dateTime = message.Substring(4, 4) + "-" + message.Substring(0, 2) + "-" + message.Substring(2, 2);
            string codeShip = message.Substring(8, 8);
            string codeDelivery = message.Substring(16, 12);
            string query = "SELECT * FROM DeliveryData WHERE(CodeDelivery = '" + codeDelivery + "') AND(DeliveryDate = CONVERT(DATETIME, '" + dateTime + "', 102)) AND(SpaceShip = '" + codeShip + "')";


            return ConnectBDD.SelectExistDelivery(query); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generarFitchersTheard.Start();

        }
    }
}




