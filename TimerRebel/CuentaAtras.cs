using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TimerRebel
{
    public partial class CuentaAtras: UserControl
    {
        int second=60;
        int minute=2;
        public bool timeOut = false;
        private bool _maxClient;
        

        public bool maxClient{

            get { return _maxClient; }
            set { _maxClient = value; }
        }

        public CuentaAtras()
        {
            InitializeComponent();        
           

    }

    public void time_Tick(object sender, EventArgs e)
        {      
            minutLabel.Text = minute.ToString().PadLeft(2, '0');
            --second;
            secondLabel.Text = second.ToString().PadLeft(2, '0');
            if (minute==0 && second==0)
            {
                time.Enabled = false;
                timeOut = true;
                Form frm = this.FindForm();

                foreach (var control in frm.Controls)
                {
                    PictureBox pic = control as PictureBox;
                    if (pic!=null)
                    {
                        if (true)
                        {
                            pic.Visible = true;
                        }
                    }
                }
                foreach (var control in frm.Controls)
                {
                    RichTextBox richText = control as RichTextBox;
                    if (richText!=null)
                    {
                        if (richText.Name.Equals("logBoxPlanet"))
                        {
                            richText.AppendText(DateTime.Now.ToString("HH:mm: ") + "¡Server: Nave enemiga destruida!" + "\n");
                        }
                    }
                }
                _maxClient = false;

            }else if (second<=0)
            {
                second = 60;
                --minute;
                minutLabel.Text = minute.ToString().PadLeft(2, '0');
            }

            
        }
        public void explosionNave() {
            timeOut = true;
            Form frm = this.FindForm();
            foreach (var control in frm.Controls)
            {
                PictureBox pic = control as PictureBox;
                if (pic != null)
                {
                    if (true)
                    {
                        pic.Visible = true;

                    }
                }
            }
        }

        public void offTimer() {
            time.Enabled = false;
        }
        public void onTimer() {
            time.Enabled = true;
        }
    }
}
