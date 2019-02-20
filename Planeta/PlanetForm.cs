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

        public PlanetForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733, path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            serverMensajeThread.Start();

            path = Application.StartupPath+ @"\hola.txt";
            Thread serverFilesThread = new Thread(() => sendTcp.sendMessage(path,"172.17.20.204",5000));
            serverFilesThread.SetApartmentState(ApartmentState.STA);
            serverFilesThread.Start();

        }


        public void planet()
        {
    



        }

        private void button1_Click(object sender, EventArgs e)
        {
             label1.Text = receTcp.Message;
        }
    }


}

