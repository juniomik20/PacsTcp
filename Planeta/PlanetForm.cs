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
        public PlanetForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733,path));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            serverMensajeThread.Start();
            //Thread serverMensaThread = new Thread(planet);
            //serverMensaThread.SetApartmentState(ApartmentState.STA);
            //serverMensaThread.Start();

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

