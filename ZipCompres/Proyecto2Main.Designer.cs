namespace Proyecto2Main
{
    partial class Proyecto2Main
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
            this.grpBoxZIP = new System.Windows.Forms.GroupBox();
            this.btnZIP = new System.Windows.Forms.Button();
            this.btnUNZIP = new System.Windows.Forms.Button();
            this.grpBoxMessages = new System.Windows.Forms.GroupBox();
            this.grpBoxCodes = new System.Windows.Forms.GroupBox();
            this.grpBoxZIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxZIP
            // 
            this.grpBoxZIP.Controls.Add(this.btnUNZIP);
            this.grpBoxZIP.Controls.Add(this.btnZIP);
            this.grpBoxZIP.Location = new System.Drawing.Point(27, 94);
            this.grpBoxZIP.Name = "grpBoxZIP";
            this.grpBoxZIP.Size = new System.Drawing.Size(96, 100);
            this.grpBoxZIP.TabIndex = 0;
            this.grpBoxZIP.TabStop = false;
            this.grpBoxZIP.Text = "ZIP and UNZIP";
            // 
            // btnZIP
            // 
            this.btnZIP.Location = new System.Drawing.Point(7, 19);
            this.btnZIP.Name = "btnZIP";
            this.btnZIP.Size = new System.Drawing.Size(75, 23);
            this.btnZIP.TabIndex = 0;
            this.btnZIP.Text = "ZIP";
            this.btnZIP.UseVisualStyleBackColor = true;
            this.btnZIP.Click += new System.EventHandler(this.btnZIP_Click);
            // 
            // btnUNZIP
            // 
            this.btnUNZIP.Location = new System.Drawing.Point(7, 58);
            this.btnUNZIP.Name = "btnUNZIP";
            this.btnUNZIP.Size = new System.Drawing.Size(75, 23);
            this.btnUNZIP.TabIndex = 1;
            this.btnUNZIP.Text = "UNZIP";
            this.btnUNZIP.UseVisualStyleBackColor = true;
            this.btnUNZIP.Click += new System.EventHandler(this.btnUNZIP_Click);
            // 
            // grpBoxMessages
            // 
            this.grpBoxMessages.Location = new System.Drawing.Point(215, 94);
            this.grpBoxMessages.Name = "grpBoxMessages";
            this.grpBoxMessages.Size = new System.Drawing.Size(200, 100);
            this.grpBoxMessages.TabIndex = 1;
            this.grpBoxMessages.TabStop = false;
            this.grpBoxMessages.Text = "Messages";
            // 
            // grpBoxCodes
            // 
            this.grpBoxCodes.Location = new System.Drawing.Point(511, 94);
            this.grpBoxCodes.Name = "grpBoxCodes";
            this.grpBoxCodes.Size = new System.Drawing.Size(200, 100);
            this.grpBoxCodes.TabIndex = 2;
            this.grpBoxCodes.TabStop = false;
            this.grpBoxCodes.Text = "Codes";
            // 
            // Proyecto2Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxCodes);
            this.Controls.Add(this.grpBoxMessages);
            this.Controls.Add(this.grpBoxZIP);
            this.Name = "Proyecto2Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto 2 Main Screen";
            this.Load += new System.EventHandler(this.Proyecto2Main_Load);
            this.grpBoxZIP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxZIP;
        private System.Windows.Forms.Button btnUNZIP;
        private System.Windows.Forms.Button btnZIP;
        private System.Windows.Forms.GroupBox grpBoxMessages;
        private System.Windows.Forms.GroupBox grpBoxCodes;
    }
}

