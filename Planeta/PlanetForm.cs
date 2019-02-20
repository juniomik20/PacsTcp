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
        FuncionSerClie.ReceTcp receTcp = new FuncionSerClie.ReceTcp();
        FuncionSerClie.SendTcp sendTcp = new FuncionSerClie.SendTcp();
        GenerarFitxers.FrmXifrasio xifrasio = new GenerarFitxers.FrmXifrasio();
        TimerRebel.CuentaAtras cuentaAtras = new TimerRebel.CuentaAtras();
        Proyecto2Main.Proyecto2Main zipCompres = new Proyecto2Main.Proyecto2Main();

        

        public PlanetForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            addLog("Planet: Iniciando el Servidor...");
            path = Application.StartupPath+ @"\";


            Thread generarFitchersTheard= new Thread(xifrasio.crearFitxers);
            

            Thread generarZipTheard = new Thread(zipCompres.Comprimir);
          

            Thread serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733, path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            Thread serverFilesThread = new Thread(() => receTcp.connecTcpPort(5000, path));
            serverFilesThread.SetApartmentState(ApartmentState.STA);


            generarFitchersTheard.Start();
            generarFitchersTheard.Join();
            addLog("Planet: Ficheros Generados...");

            generarZipTheard.Start();
            generarZipTheard.Join();
            addLog("Planet: Zip Generado...");

            serverMensajeThread.Start();
            serverFilesThread.Start(); 
            
        }


        void planetaFunc() {
          
         
                    addLog(receTcp.Message);
                



        }

        public void addLog(string message)
        {
            logBoxPlanet.AppendText(DateTime.Now.ToString("HH:mm: ") + message + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            planetaFunc();


        }
    }


}

