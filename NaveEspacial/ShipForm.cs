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
        FuncionSerClie.SendTcp sendTcp = new FuncionSerClie.SendTcp();
        FuncionSerClie.ReceTcp receTcp = new FuncionSerClie.ReceTcp();

        ConnectionClass.ConnectBDD connectBDD = new ConnectionClass.ConnectBDD();

        public ShipForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"PacsSol.txt";
            sendTcp.sendMessage(identifiMessage(), "172.17.20.204", 8733);

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
            Thread serverMensajeThread = new Thread(() => receTcp.connecTcpPort(8733,));
            serverMensajeThread.SetApartmentState(ApartmentState.STA);
            serverMensajeThread.Start();
        }
    }
}
