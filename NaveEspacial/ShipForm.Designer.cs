namespace NaveEspacial
{
    partial class ShipForm
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.logBoxShip = new System.Windows.Forms.RichTextBox();
            this.cuentaAtras1 = new TimerRebel.CuentaAtras();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(233, 310);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(54, 52);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // logBoxShip
            // 
            this.logBoxShip.BackColor = System.Drawing.SystemColors.MenuText;
            this.logBoxShip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBoxShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.logBoxShip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.logBoxShip.Location = new System.Drawing.Point(1, 183);
            this.logBoxShip.Name = "logBoxShip";
            this.logBoxShip.ReadOnly = true;
            this.logBoxShip.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.logBoxShip.Size = new System.Drawing.Size(158, 82);
            this.logBoxShip.TabIndex = 1;
            this.logBoxShip.Text = "";
            // 
            // cuentaAtras1
            // 
            this.cuentaAtras1.BackColor = System.Drawing.Color.Transparent;
            this.cuentaAtras1.Location = new System.Drawing.Point(331, -9);
            this.cuentaAtras1.maxClient = false;
            this.cuentaAtras1.Name = "cuentaAtras1";
            this.cuentaAtras1.Size = new System.Drawing.Size(147, 71);
            this.cuentaAtras1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::NaveEspacial.Properties.Resources.explosion;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NaveEspacial.Properties.Resources.screenshot_0050;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cuentaAtras1);
            this.Controls.Add(this.logBoxShip);
            this.Controls.Add(this.ConnectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShipForm";
            this.Text = "shipForm";
            this.Load += new System.EventHandler(this.ShipForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.RichTextBox logBoxShip;
        private TimerRebel.CuentaAtras cuentaAtras1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

