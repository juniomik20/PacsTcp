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
        string path = Application.StartupPath;
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
            path = Application.StartupPath + @"\";


            generarFitchersTheard = new Thread(generarFicheros);
            generarZipTheard = new Thread(generarZip);

            serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733, path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            serverFilesThread = new Thread(() => receTcp.connecTcpPort(5000, path));
            serverFilesThread.SetApartmentState(ApartmentState.STA);


            generarFitchersTheard.Start();
            serverMensajeThread.Start();
            serverFilesThread.Start();

        }



        void generarFicheros()
        {
           // xifrasio.crearFitxers();
        }

        void generarZip()
        {
           //// generarFitchersTheard.Join();
           // generarZipTheard.Start();
            generarZipTheard.Join();
            zipCompres.Comprimir();
        }



        public void addLog(string message)
        {
            logBoxPlanet.AppendText(DateTime.Now.ToString("HH:mm: ") + message + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread planetThread = new Thread(planet);
            planetThread.Start();
        }
        void planet()
        {

           
                if (logBoxPlanet.InvokeRequired)
                {
                    logBoxPlanet.Invoke(new MethodInvoker(() => {addLog(receTcp.Message);}));
                }
                else
                {
                    addLog(receTcp.Message);

                }


            }

        }
    }




