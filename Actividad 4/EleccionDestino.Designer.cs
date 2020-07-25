namespace ProyectoFinal
{
    partial class EleccionDestino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBoxDestino = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxDestino
            // 
            this.PictureBoxDestino.Location = new System.Drawing.Point(9, 9);
            this.PictureBoxDestino.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBoxDestino.Name = "PictureBoxDestino";
            this.PictureBoxDestino.Size = new System.Drawing.Size(930, 561);
            this.PictureBoxDestino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxDestino.TabIndex = 2;
            this.PictureBoxDestino.TabStop = false;
            this.PictureBoxDestino.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxDestino_MouseClick);
            // 
            // EleccionDestino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 580);
            this.Controls.Add(this.PictureBoxDestino);
            this.Name = "EleccionDestino";
            this.Text = "EleccionDestino";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDestino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxDestino;
    }
}