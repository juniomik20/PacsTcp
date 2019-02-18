using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaveEspacial
{
    public partial class ShipForm : Form
    {
        FuncionSerClie.SendTcp sendTcp = new FuncionSerClie.SendTcp();

        public ShipForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            sendTcp.sendMessage("hola", "172.17.20.204", 5000);
        }
    }
}
