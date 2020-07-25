using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class EleccionDestino : Form
    {
        Grafo G;
        Bitmap Animacion;
        Brush origen = new SolidBrush(Color.DeepSkyBlue);
        Brush destino = new SolidBrush(Color.Green);
        Point Coordenadas;
        Vertice Destino;
        public EleccionDestino(Grafo grafo, Vertice Origen, Bitmap Fondo)
        {
            InitializeComponent();
            G = grafo;
            Rectangle Dimensiones = new Rectangle(0, 0, Fondo.Width, Fondo.Height);
            System.Drawing.Imaging.PixelFormat Formato = Fondo.PixelFormat;
            Animacion = Fondo.Clone(Dimensiones, Formato);
            PictureBoxDestino.BackgroundImage = Fondo;
            Coordenadas = new Point(Origen.getX(),Origen.getY());
            LimpiarBitmap(Animacion, Color.Transparent);
            DibujarCirculo(Coordenadas, origen, Animacion);
            PictureBoxDestino.Image = Animacion;
            MessageBox.Show("Seleccione un Vertice Destino");
        }

        void LimpiarBitmap(Bitmap bmp, Color c)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(c);
        }

        void DibujarCirculo(Point punto, Brush brocha, Bitmap bmp)
        {
            int r = 16;
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.FillEllipse(brocha, punto.X - r, punto.Y - r, r * 2, r * 2);
        }

        Vertice VerticeCercano(Point Coordenada)
        {
            List<Vertice> lv = G.getLv();
            bool PrimerVertice = true;
            Vertice Cercano = null;
            foreach (Vertice v in lv)
            {
                if (PrimerVertice == true)
                {
                    Cercano = v;
                    PrimerVertice = false;
                }
                else
                {
                    int DifCercano = Math.Abs(Coordenada.X - Cercano.getX()) + Math.Abs(Coordenada.Y - Cercano.getY());
                    int DifNuevo = Math.Abs(Coordenada.X - v.getX()) + Math.Abs(Coordenada.Y - v.getY());
                    if (DifNuevo < DifCercano)
                        Cercano = v;
                }
            }
            return Cercano;
        }

        private void PictureBoxDestino_MouseClick(object sender, MouseEventArgs e)
        {
            Point CoordenadaElegido = new Point(e.X, e.Y);
            Vertice Cercano = VerticeCercano(CoordenadaElegido);
            Point CoordenadaDestino = new Point(Cercano.getX(),Cercano.getY());
            DibujarCirculo(CoordenadaDestino, destino, Animacion);
            PictureBoxDestino.Refresh();
            Destino = Cercano;
            Thread.Sleep(50);
            this.Dispose();
        }

        public Vertice GetDestino()
        {
            return Destino;
        }
    }
}
