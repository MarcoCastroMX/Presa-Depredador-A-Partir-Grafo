namespace ProyectoFinal
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label labelMenor;
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.labelMenor = new System.Windows.Forms.Label();
            this.CbNumPresas = new System.Windows.Forms.ComboBox();
            this.ListaRadar = new System.Windows.Forms.ListBox();
            this.ListaDepredadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbNumDepredadoras = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BtnIngresarAgentes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NumAgentes = new System.Windows.Forms.Label();
            this.BtnAnimacion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarImagen.Location = new System.Drawing.Point(942, 12);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(375, 54);
            this.btnCargarImagen.TabIndex = 0;
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.BtnCargarImagenClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(930, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(1092, 591);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(92, 39);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrarClick);
            // 
            // labelMenor
            // 
            this.labelMenor.Location = new System.Drawing.Point(9, 681);
            this.labelMenor.Name = "labelMenor";
            this.labelMenor.Size = new System.Drawing.Size(996, 23);
            this.labelMenor.TabIndex = 7;
            // 
            // CbNumPresas
            // 
            this.CbNumPresas.Enabled = false;
            this.CbNumPresas.FormattingEnabled = true;
            this.CbNumPresas.Location = new System.Drawing.Point(1136, 84);
            this.CbNumPresas.Name = "CbNumPresas";
            this.CbNumPresas.Size = new System.Drawing.Size(181, 21);
            this.CbNumPresas.TabIndex = 8;
            this.CbNumPresas.SelectedIndexChanged += new System.EventHandler(this.CbNumPresas_SelectedIndexChanged);
            // 
            // ListaRadar
            // 
            this.ListaRadar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaRadar.FormattingEnabled = true;
            this.ListaRadar.Location = new System.Drawing.Point(943, 443);
            this.ListaRadar.Name = "ListaRadar";
            this.ListaRadar.Size = new System.Drawing.Size(374, 147);
            this.ListaRadar.TabIndex = 10;
            // 
            // ListaDepredadores
            // 
            this.ListaDepredadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaDepredadores.FormattingEnabled = true;
            this.ListaDepredadores.Location = new System.Drawing.Point(949, 276);
            this.ListaDepredadores.Name = "ListaDepredadores";
            this.ListaDepredadores.Size = new System.Drawing.Size(361, 121);
            this.ListaDepredadores.TabIndex = 19;
            this.ListaDepredadores.SelectedIndexChanged += new System.EventHandler(this.ListaDepredadores_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(946, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ingrese # de Presas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(946, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ingrese # de Depredadores:";
            // 
            // CbNumDepredadoras
            // 
            this.CbNumDepredadoras.Enabled = false;
            this.CbNumDepredadoras.FormattingEnabled = true;
            this.CbNumDepredadoras.Location = new System.Drawing.Point(1136, 126);
            this.CbNumDepredadoras.Name = "CbNumDepredadoras";
            this.CbNumDepredadoras.Size = new System.Drawing.Size(181, 21);
            this.CbNumDepredadoras.TabIndex = 22;
            this.CbNumDepredadoras.SelectedIndexChanged += new System.EventHandler(this.CbNumDepredadoras_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(962, 174);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 22);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Aleatorio";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BtnIngresarAgentes
            // 
            this.BtnIngresarAgentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIngresarAgentes.Location = new System.Drawing.Point(1062, 162);
            this.BtnIngresarAgentes.Name = "BtnIngresarAgentes";
            this.BtnIngresarAgentes.Size = new System.Drawing.Size(248, 45);
            this.BtnIngresarAgentes.TabIndex = 24;
            this.BtnIngresarAgentes.Text = "Ingresar Presas y Depredadores";
            this.BtnIngresarAgentes.UseVisualStyleBackColor = true;
            this.BtnIngresarAgentes.Click += new System.EventHandler(this.BtnIngresarAgentes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1166, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ingresados:";
            // 
            // NumAgentes
            // 
            this.NumAgentes.AutoSize = true;
            this.NumAgentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAgentes.Location = new System.Drawing.Point(1285, 225);
            this.NumAgentes.Name = "NumAgentes";
            this.NumAgentes.Size = new System.Drawing.Size(0, 18);
            this.NumAgentes.TabIndex = 26;
            // 
            // BtnAnimacion
            // 
            this.BtnAnimacion.Enabled = false;
            this.BtnAnimacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnimacion.Location = new System.Drawing.Point(949, 403);
            this.BtnAnimacion.Name = "BtnAnimacion";
            this.BtnAnimacion.Size = new System.Drawing.Size(361, 34);
            this.BtnAnimacion.TabIndex = 27;
            this.BtnAnimacion.Text = "Iniciar Animacion";
            this.BtnAnimacion.UseVisualStyleBackColor = true;
            this.BtnAnimacion.Click += new System.EventHandler(this.BtnAnimacion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(958, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Seleccione un Depredador Principal:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 641);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnAnimacion);
            this.Controls.Add(this.NumAgentes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnIngresarAgentes);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CbNumDepredadoras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListaDepredadores);
            this.Controls.Add(this.ListaRadar);
            this.Controls.Add(this.CbNumPresas);
            this.Controls.Add(this.labelMenor);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCargarImagen);
            this.Name = "MainForm";
            this.Text = "Actividad 4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox CbNumPresas;
        private System.Windows.Forms.ListBox ListaRadar;
        private System.Windows.Forms.ListBox ListaDepredadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbNumDepredadoras;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BtnIngresarAgentes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NumAgentes;
        private System.Windows.Forms.Button BtnAnimacion;
        private System.Windows.Forms.Label label4;
    }
}