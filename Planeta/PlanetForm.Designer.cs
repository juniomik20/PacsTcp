namespace Planeta
{
    partial class PlanetForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBoxPlanet = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cuentaAtras1 = new TimerRebel.CuentaAtras();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // logBoxPlanet
            // 
            this.logBoxPlanet.BackColor = System.Drawing.SystemColors.WindowText;
            this.logBoxPlanet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBoxPlanet.ForeColor = System.Drawing.Color.Lime;
            this.logBoxPlanet.Location = new System.Drawing.Point(171, 90);
            this.logBoxPlanet.Name = "logBoxPlanet";
            this.logBoxPlanet.ReadOnly = true;
            this.logBoxPlanet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logBoxPlanet.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.logBoxPlanet.Size = new System.Drawing.Size(219, 159);
            this.logBoxPlanet.TabIndex = 12;
            this.logBoxPlanet.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Planeta.Properties.Resources.MatureShamefulFoxterrier_size_restricted;
            this.pictureBox1.Location = new System.Drawing.Point(386, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cuentaAtras1
            // 
            this.cuentaAtras1.BackColor = System.Drawing.Color.Black;
            this.cuentaAtras1.Location = new System.Drawing.Point(609, 142);
            this.cuentaAtras1.maxClient = false;
            this.cuentaAtras1.Name = "cuentaAtras1";
            this.cuentaAtras1.Size = new System.Drawing.Size(147, 71);
            this.cuentaAtras1.TabIndex = 16;
            this.cuentaAtras1.Visible = false;
            // 
            // PlanetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Planeta.Properties.Resources.TodoControlado;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cuentaAtras1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logBoxPlanet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlanetForm";
            this.Text = "PlanetForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox logBoxPlanet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private TimerRebel.CuentaAtras cuentaAtras1;
    }
}

