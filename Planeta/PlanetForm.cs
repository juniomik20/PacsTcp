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
            path = Application.StartupPath+ @"\hola.txt";


            Thread serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733, path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            Thread serverFilesThread = new Thread(() => receTcp.connecTcpPort(5000, path));
            serverFilesThread.SetApartmentState(ApartmentState.STA);

            serverMensajeThread.Start();

            
            
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

