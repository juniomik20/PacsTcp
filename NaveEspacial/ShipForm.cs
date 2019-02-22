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
        string path;
        public ShipForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            //sendTcp.sendMessage(identifiMessage(), "172.17.20.204", 8733);
            sendTcp.sendMessage("hola", "192.168.1.24", 8733);

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
            path = Application.StartupPath+@"\Hola.txt";
            Thread ServerShipMessage = new Thread(() => receTcp.connecTcpPort(8733,path));
            ServerShipMessage.SetApartmentState(ApartmentState.STA);
            ServerShipMessage.Start();
            Thread ServerShipFiles = new Thread(() => receTcp.connecTcpPort(5000, path));
            ServerShipFiles.SetApartmentState(ApartmentState.STA);
            ServerShipFiles.Start();


        }
    }
}
