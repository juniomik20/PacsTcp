namespace TimerRebel
{
    partial class CuentaAtras
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

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.secondLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minutLabel = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // secondLabel
            // 
            this.secondLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondLabel.AutoSize = true;
            this.secondLabel.BackColor = System.Drawing.Color.Transparent;
            this.secondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.secondLabel.Location = new System.Drawing.Point(74, 24);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(46, 31);
            this.secondLabel.TabIndex = 10;
            this.secondLabel.Text = "00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(57, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = ":";
            // 
            // minutLabel
            // 
            this.minutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minutLabel.BackColor = System.Drawing.Color.Transparent;
            this.minutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minutLabel.Location = new System.Drawing.Point(13, 24);
            this.minutLabel.Name = "minutLabel";
            this.minutLabel.Size = new System.Drawing.Size(50, 31);
            this.minutLabel.TabIndex = 8;
            this.minutLabel.Text = "03";
            this.minutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.Interval = 1000;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // CuentaAtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minutLabel);
            this.Name = "CuentaAtras";
            this.Size = new System.Drawing.Size(147, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minutLabel;
        private System.Windows.Forms.Timer time;
    }
}
