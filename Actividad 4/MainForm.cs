using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        private string NombreImagen;
        Bitmap Picture, Grafo,copia, Animacion;
        bool Inserciones=false;
        int ContVertices;
        const int k = 3;
        Color Negro = Color.FromArgb(255, 0, 0, 0);
        Color Rojo = Color.FromArgb(255, 255, 0, 0);
        Color Blanco = Color.FromArgb(255, 255, 255, 255);
        Color Azul = Color.FromArgb(255, 0, 0, 255);
        Font drawFont = new Font("Arial", 8);
        Color colorpixel;
        Point p_0, p_f;
        Grafo G;
        Vertice Vaux;
        List<Point> Resultado;
        Brush BrochaID,BrochaPresa,BrochaDepredador;
        List<Agente> Presa = new List<Agente>();
        List<Agente> Depredador = new List<Agente>();
        List<Vertice> Usados = new List<Vertice>();
        Agente DepredadorPrincipal;

        public MainForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            p_0 = new Point();
            p_f = new Point();
            Resultado = new List<Point>();
            BrochaID = new SolidBrush(Color.GhostWhite);
            BrochaPresa = new SolidBrush(Color.DeepSkyBlue);
            BrochaDepredador = new SolidBrush(Color.DarkRed);
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void BtnCargarImagenClick(object sender, EventArgs e) {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    NombreImagen = openFileDialog1.FileName;
                    Image imagen = Image.FromFile(NombreImagen);
                    Picture = new Bitmap(imagen,pictureBox1.Width,pictureBox1.Height);
                    Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
                    System.Drawing.Imaging.PixelFormat Formato = Picture.PixelFormat;
                    Grafo = Picture.Clone(Dimensiones, Formato);
                    pictureBox1.Image = Picture;
                    labelMenor.Text = "";
                    this.BtnAnimacion.Enabled = false;
                    this.CbNumPresas.Enabled = false;
                    this.CbNumDepredadoras.Enabled = false;
                    this.CbNumPresas.Text = "";
                    this.CbNumDepredadoras.Text = "";
                    this.BtnIngresarAgentes.Enabled = false;
                    G = new Grafo();
                    ListaRadar.Items.Clear();
                    ListaDepredadores.Items.Clear();
                    ContVertices = 1;
                    this.CbNumPresas.Items.Clear();
                    this.CbNumDepredadoras.Items.Clear();
                    int x, y;
                    List<Vertice> lv = G.getLv();
                    for (y = 0; y < Picture.Height; y += 20){
                        for (x = 0; x < Picture.Width; x += 20){
                            colorpixel = Picture.GetPixel(x, y);
                            if (colorpixel == Negro){
                                Vaux = EncontrarCentro(x, y);
                                if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY()))){
                                    ContVertices--;
                                }
                                else{
                                    if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY() + 1))){
                                        ContVertices--;
                                    }
                                    else{
                                        if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY()))){
                                            ContVertices--;
                                        }
                                        else{
                                            if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY() - 1))){
                                                ContVertices--;
                                            }
                                            else{
                                                if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY()))){
                                                    ContVertices--;
                                                }
                                                else{
                                                    if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY() + 1))){
                                                        ContVertices--;
                                                    }
                                                    else{
                                                        if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY() - 1))){
                                                            ContVertices--;
                                                        }
                                                        else{
                                                            if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY() - 1))){
                                                                ContVertices--;
                                                            }
                                                            else{
                                                                if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY() + 1))){
                                                                    ContVertices--;
                                                                }
                                                                else{
                                                                    lv.Add(Vaux);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Graphics graphics = Graphics.FromImage(Grafo);
                    for (int i = 0; i < lv.Count; i++){
                        for (int j = 0; j < lv.Count; j++){
                            p_0.X = lv[i].getX();
                            p_0.Y = lv[i].getY();
                            p_f.X = lv[j].getX();
                            p_f.Y = lv[j].getY();
                            if (lv[i].getId().ToString() == lv[j].getId().ToString()){
                            }
                            else{
                                List<Point> Resultado = DDA();
                                if (Resultado != null){
                                    pictureBox1.Refresh();
                                    double distancia = Math.Sqrt(Math.Pow((double)p_f.X - (double)p_0.X, 2) + Math.Pow((double)p_f.Y - (double)p_0.Y, 2));
                                    lv[i].addArista(lv[j], distancia, lv[i], Resultado);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < lv.Count; i++){
                        List<Arista> la = lv[i].getLa();
                        DibujarCentro(lv[i].getX(), lv[i].getY());
                        graphics.DrawString(lv[i].getId().ToString(), drawFont, BrochaID, lv[i].getX(), lv[i].getY());
                    }
                    for (int i = 1; i < lv.Count; i++){
                        CbNumPresas.Items.Add(i);
                        CbNumDepredadoras.Items.Add(i);
                    }
                    this.CbNumPresas.Enabled = true;
                    this.CbNumDepredadoras.Enabled = true;
                    ContVertices = 0;
                    this.NumAgentes.Text = ContVertices.ToString();
                    pictureBox1.BackgroundImage = Grafo;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                    Animacion = Grafo.Clone(Dimensiones, Formato);
                    copia = Grafo.Clone(Dimensiones, Formato);
                    pictureBox1.Image = Animacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        Vertice EncontrarCentro(int x, int y){
            int x_i, x_f, x_act, x_c;
            int y_i, y_f, y_act, y_c;
            y_act = y;
            y_i = y;
            do{
                colorpixel = Picture.GetPixel(x, ++y_act);
            } while (colorpixel == Negro || colorpixel == Rojo);
            y_f = y_act - 1;
            y_act = y;
            do{
                colorpixel = Picture.GetPixel(x, --y_act);
            } while (colorpixel == Negro || colorpixel == Rojo);
            y_i = y_act + 1;
            y_c = (y_i + y_f) / 2;
            x_act = x;
            do{
                colorpixel = Picture.GetPixel(--x_act, y_c);
            } while (colorpixel == Negro || colorpixel == Rojo);
            x_i = x_act + 1;
            x_act = x;
            do{
                colorpixel = Picture.GetPixel(++x_act, y_c);
            } while (colorpixel == Negro || colorpixel == Rojo);
            x_f = x_act - 1;
            x_c = (x_f + x_i) / 2;
            int r = (x_f - x_c);
            Vertice vertice = new Vertice(x_c, y_c, r, ContVertices++);
            return vertice;
        }

        List<Point> DDA()
        {
            double m = ((double)p_f.Y - (double)p_0.Y) / ((double)p_f.X - (double)p_0.X);
            double b = (double)p_0.Y - (double)m * (double)p_0.X;
            double y_i, x_i;
            bool band = false;
            bool band2 = false;
            int inc = 1;
            Point Coordenadas;
            List<Point> Linea = new List<Point>();
            Coordenadas = new Point();
            if (Double.IsInfinity(m))
            {
                if (p_0.Y > p_f.Y)
                    inc = -1;
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc)
                {
                    x_i = p_0.X;
                    colorpixel = Picture.GetPixel((int)Math.Round(x_i), (int)y_i);
                    if (colorpixel == Blanco)
                    {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true)
                    {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true)
                    {
                        return null;
                    }
                }
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc)
                {
                    x_i = p_0.X;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
            if (m <= 1 && m >= -1)
            {
                if (p_0.X > p_f.X)
                    inc = -1;
                for (x_i = p_0.X; (int)x_i != p_f.X; x_i += inc)
                {
                    y_i = m * x_i + b;
                    colorpixel = Picture.GetPixel((int)x_i, (int)Math.Round(y_i));
                    if (colorpixel == Blanco)
                    {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true)
                    {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true)
                    {
                        return null;
                    }
                }
                for (x_i = p_0.X; (int)x_i != p_f.X; x_i += inc)
                {
                    y_i = m * x_i + b;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)Math.Round(y_i);
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
            else
            {
                if (p_0.Y > p_f.Y)
                    inc = -1;
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc)
                {
                    x_i = (y_i - b) / m;
                    colorpixel = Picture.GetPixel((int)Math.Round(x_i), (int)y_i);
                    if (colorpixel == Blanco)
                    {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true)
                    {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true)
                    {
                        return null;
                    }
                }
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc)
                {
                    x_i = (y_i - b) / m;
                    Coordenadas.X = (int)Math.Round(x_i);
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
        }

        void DibujarCentro(int x, int y){
            for (int i = -k; i <= k; i++){
                for (int j = -k; j <= k; j++){
                    Grafo.SetPixel(x + i, y + j, Rojo);
                    pictureBox1.Image = Grafo;
                }
            }
        }

        void BtnCerrarClick(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void CbNumPresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarBitmap(Animacion, Color.Transparent);
            Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
            System.Drawing.Imaging.PixelFormat Formato = Picture.PixelFormat;
            Grafo = copia.Clone(Dimensiones, Formato);
            pictureBox1.BackgroundImage = Grafo;
            pictureBox1.Refresh();
            this.CbNumDepredadoras.Items.Clear();
            int Elegido = this.CbNumPresas.SelectedIndex + 1;
            int Sobrantes = G.getLv().Count - Elegido;
            for (int i = 1; i <= Sobrantes; i++)
            {
                this.CbNumDepredadoras.Items.Add(i);
            }
            if (CbNumDepredadoras.Text != "" && CbNumPresas.Text!="")
                this.BtnIngresarAgentes.Enabled = true;
            Inserciones = false;
            ContVertices = 0;
            this.NumAgentes.Text = ContVertices.ToString();
            Usados.Clear();
            ListaDepredadores.Items.Clear();
            ListaRadar.Items.Clear();
        }

        private void CbNumDepredadoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarBitmap(Animacion, Color.Transparent);
            Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
            System.Drawing.Imaging.PixelFormat Formato = Picture.PixelFormat;
            Grafo = copia.Clone(Dimensiones, Formato);
            pictureBox1.BackgroundImage = Grafo;
            pictureBox1.Refresh();
            this.CbNumPresas.Items.Clear();
            int Elegido = this.CbNumDepredadoras.SelectedIndex + 1;
            int Sobrantes = G.getLv().Count - Elegido;
            for (int i = 1; i <= Sobrantes; i++)
            {
                this.CbNumPresas.Items.Add(i);
            }
            if (CbNumPresas.Text != "" && CbNumDepredadoras.Text != "")
                this.BtnIngresarAgentes.Enabled = true;
            Inserciones = false;
            ContVertices = 0;
            this.NumAgentes.Text = ContVertices.ToString();
            Usados.Clear();
            ListaDepredadores.Items.Clear();
            ListaRadar.Items.Clear();
        }

        void DibujarCirculo(Point punto, Brush brocha, Bitmap bmp) {
            int r = 16;
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.FillEllipse(brocha, punto.X - r, punto.Y - r, r * 2, r * 2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarBitmap(Animacion, Color.Transparent);
            Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
            System.Drawing.Imaging.PixelFormat Formato = Picture.PixelFormat;
            Grafo = copia.Clone(Dimensiones, Formato);
            pictureBox1.BackgroundImage = Grafo;
            pictureBox1.Refresh();
            Inserciones = false;
            ContVertices = 0;
            this.NumAgentes.Text = ContVertices.ToString();
            Usados.Clear();
            Presa.Clear();
            Depredador.Clear();
            ListaDepredadores.Items.Clear();
            ListaRadar.Items.Clear();
        }

        private void BtnIngresarAgentes_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                List<Vertice> lv = G.getLv();
                Presa.Clear();
                Depredador.Clear();
                ListaDepredadores.Items.Clear();
                LimpiarBitmap(Animacion, Color.Transparent);
                pictureBox1.Refresh();
                Random random = new Random();
                int id=1;
                int[] numeros = new int[lv.Count];
                int cont = 0;
                int Elegido = int.Parse(CbNumPresas.Text)+int.Parse(CbNumDepredadoras.Text)+1;
                bool BanderaIgual;
                int Aristas = 0;             
                foreach (Vertice v in lv)
                {
                    Aristas = Aristas + v.getLa().Count;
                }
                if (Aristas == 0)
                    return;
                for (int j = 1; j < Elegido; j++)
                {
                    int NumeroAleatorio = random.Next(1, lv.Count + 1);
                    BanderaIgual = false;
                    for (int i = 0; i < cont; i++)
                    {
                        if (NumeroAleatorio.Equals(numeros[i]))
                        {
                            BanderaIgual = true;
                            break;
                        }
                    }
                    if (BanderaIgual == false)
                    {
                        for (int i = 0; i < lv.Count; i++)
                        {
                            if (NumeroAleatorio == lv[i].getId())
                            {
                                List<Vertice> Visitados = new List<Vertice>();
                                Stack<Vertice> Pila = new Stack<Vertice>();
                                List<Vertice> Posible = new List<Vertice>();
                                if (cont < int.Parse(CbNumPresas.Text))
                                {
                                    Vertice DestinoElegido = lv[i];
                                    do
                                    {
                                        EleccionDestino Destino = new EleccionDestino(G, lv[i], Grafo);
                                        Destino.ShowDialog();
                                        DestinoElegido = Destino.GetDestino();
                                        Pila.Push(lv[i]);
                                        Visitados.Add(lv[i]);
                                        Posible.Add(lv[i]);
                                        DFS(Pila,Visitados,Posible);
                                        bool Imposible = true;
                                        foreach(Vertice v in Posible)
                                        {
                                            if (v.Equals(DestinoElegido))
                                            {
                                                Imposible = false;
                                                break;
                                            }
                                        }
                                        if (Imposible == true)
                                            DestinoElegido = lv[i];
                                    } while (DestinoElegido == lv[i]);
                                    Dijkstra D = new Dijkstra(G, lv[i],DestinoElegido);
                                    D.GetCamino().Reverse();
                                    Agente presa = new Agente(lv[i], id, DestinoElegido,D.GetCamino());
                                    Point Punto = new Point(lv[i].getX(), lv[i].getY());
                                    DibujarCirculo(Punto, BrochaPresa, Animacion);
                                    Presa.Add(presa);
                                }
                                else
                                {
                                    Pila.Push(lv[i]);
                                    Visitados.Add(lv[i]);
                                    Posible.Add(lv[i]);
                                    DFS(Pila, Visitados, Posible);
                                    Agente depredador = new Agente(lv[i], id, null,Posible);
                                    Point Punto = new Point(lv[i].getX(), lv[i].getY());
                                    DibujarCirculo(Punto, BrochaDepredador, Animacion);
                                    ListaDepredadores.Items.Add(depredador.ToString());
                                    Depredador.Add(depredador);
                                }
                                pictureBox1.Refresh();
                                id++;
                                numeros[cont] = NumeroAleatorio;
                                cont++;
                            }
                        }
                    }
                    else
                        j--;
                }
                this.NumAgentes.Text = cont.ToString();
            }
            else
            {
                if (ContVertices == 0)
                {
                    MessageBox.Show("Haga Click en los Vertices en los Cuales desea Ingresar a las Presas y Depredadoras");
                    ListaDepredadores.Items.Clear();
                    Presa.Clear();
                    Depredador.Clear();
                    Inserciones = true;
                }
                if(Inserciones ==true && ContVertices!= int.Parse(CbNumPresas.Text) + int.Parse(CbNumDepredadoras.Text))
                {
                    if (ContVertices != 0)
                        MessageBox.Show("Presas o Depredadores Faltantes de Ingresar");
                }
                else
                {
                    LimpiarBitmap(Animacion, Color.Transparent);
                    pictureBox1.Refresh();
                    Inserciones = false;
                    ContVertices = 0;
                    this.NumAgentes.Text = ContVertices.ToString();
                    Usados.Clear();
                }    
            }
        }

        private void ListaDepredadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Indice = ListaDepredadores.SelectedIndex;
            int idBuscado = int.Parse(CbNumPresas.Text) + Indice + 1;
            foreach(Agente a in Depredador)
            {
                if (a.getId() == idBuscado)
                {
                    DepredadorPrincipal = a;
                    break;
                }
            }
            this.BtnAnimacion.Enabled = true;
        }

        Vertice VerticeCercano(Point Coordenada)
        {
            List<Vertice> lv = G.getLv();
            bool PrimerVertice = true;
            Vertice Cercano=null;
            foreach(Vertice v in lv)
            {
                if (PrimerVertice == true)
                {
                    Cercano = v;
                    PrimerVertice = false;
                }
                else
                {
                    int DifCercano = Math.Abs(Coordenada.X-Cercano.getX())+Math.Abs(Coordenada.Y-Cercano.getY());
                    int DifNuevo = Math.Abs(Coordenada.X - v.getX()) + Math.Abs(Coordenada.Y - v.getY());
                    if (DifNuevo < DifCercano)
                        Cercano = v;
                }
            }
            return Cercano;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            List<Vertice> Visitados = new List<Vertice>();
            Stack<Vertice> Pila = new Stack<Vertice>();
            List<Vertice> Posible = new List<Vertice>();
            if (CbNumPresas.Text == "" || CbNumDepredadoras.Text == "")
                return;
            if(ContVertices<int.Parse(CbNumPresas.Text) + int.Parse(CbNumDepredadoras.Text))
            {
                Point Coordenada = new Point(e.X, e.Y);
                Vertice Cercano = VerticeCercano(Coordenada);
                if (!Usados.Contains(Cercano))
                {
                    if (ContVertices < int.Parse(CbNumPresas.Text))
                    {
                        Point Punto = new Point(Cercano.getX(), Cercano.getY());
                        DibujarCirculo(Punto, BrochaPresa, Animacion);
                        pictureBox1.Refresh();
                        Vertice DestinoElegido = Cercano;
                        do
                        {
                            EleccionDestino Destino = new EleccionDestino(G, Cercano, Grafo);
                            Destino.ShowDialog();
                            DestinoElegido = Destino.GetDestino();
                            Pila.Push(Cercano);
                            Visitados.Add(Cercano);
                            Posible.Add(Cercano);
                            DFS(Pila, Visitados, Posible);
                            bool Imposible = true;
                            foreach (Vertice v in Posible)
                            {
                                if (v.Equals(DestinoElegido))
                                {
                                    Imposible = false;
                                    break;
                                }
                            }
                            if (Imposible == true)
                                DestinoElegido = Cercano;
                        } while (DestinoElegido == Cercano);
                        Dijkstra D = new Dijkstra(G,Cercano,DestinoElegido);
                        D.GetCamino().Reverse();
                        Agente presa = new Agente(Cercano, ++ContVertices, DestinoElegido,D.GetCamino());
                        Presa.Add(presa);
                    }
                    else
                    {
                        Pila.Push(Cercano);
                        Visitados.Add(Cercano);
                        Posible.Add(Cercano);
                        DFS(Pila, Visitados, Posible);
                        Agente depredador = new Agente(Cercano, ++ContVertices, null,Posible);
                        Point Punto = new Point(Cercano.getX(), Cercano.getY());
                        DibujarCirculo(Punto, BrochaDepredador, Animacion);
                        ListaDepredadores.Items.Add(depredador.ToString());
                        Depredador.Add(depredador);
                    }
                    pictureBox1.Refresh();
                    this.NumAgentes.Text = ContVertices.ToString();
                    Usados.Add(Cercano);
                }
            }
        }

        private void BtnAnimacion_Click(object sender, EventArgs e)
        {
            List<Vertice> lv = G.getLv();
            Graphics graphics = Graphics.FromImage(Animacion);
            pictureBox1.Image = Animacion;
            List<Point> Linea = new List<Point>();
            List<Point> Puntos = new List<Point>();
            Point punto = new Point();
            int a = 0, b, c;
            int x = 0, y, z;
            while (Presa.Count != 0)
            {
                b = Presa[a].GetcontAristas();
                foreach (Arista arista in Presa[a].getCaminoActual()[b].getLa())
                {
                    if (arista.getVertex().Equals(Presa[a].getCaminoActual()[b + 1]))
                    {
                        Linea = arista.getLinea();
                        Presa[a].SetAristaActual(arista);
                    }   
                }
                c = Presa[a].GetcontPuntos();
                if (Linea.Count - 1 <= c)//5
                    c = Linea.Count - 1;
                punto = Linea[c];
                Presa[a].SetPuntoActual(punto);
                Puntos.Add(punto);
                DibujarCirculo(punto, BrochaPresa, Animacion);
                DibujarId(punto, BrochaID, Animacion, Presa[a].getId());
                Presa[a].SetcontPunto(Presa[a].GetcontPuntos() + 1);//5
                if (Presa[a].GetcontPuntos() >= Linea.Count)
                {
                    Presa[a].SetcontPunto(0);
                    Presa[a].SetcontAristas(Presa[a].GetcontAristas() + 1);
                }
                if (Presa[a].GetcontAristas() == Presa[a].getCaminoActual().Count-1)
                {
                    DibujarCirculo(punto, BrochaPresa, Grafo);
                    pictureBox1.BackgroundImage = Grafo;
                    Presa.Remove(Presa[a]);
                }
                a++;
                if (a >= Presa.Count)
                {
                    a = 0;
                    while (true)
                    {
                        bool Principal = false;
                        if (Depredador[x].Equals(DepredadorPrincipal))
                            Principal = true;
                        y = Depredador[x].GetcontAristas();
                        foreach (Arista arista in Depredador[x].getCaminoActual()[y].getLa())
                        {
                            if (arista.getVertex().getId() == Depredador[x].getCaminoActual()[y + 1].getId())
                            {
                                Linea = arista.getLinea();
                                Depredador[x].SetAristaActual(arista);
                            }  
                        }
                        z = Depredador[x].GetcontPuntos();
                        if (Linea.Count - 1 <= z)
                            z = Linea.Count - 1;
                        punto = Linea[z];
                        Point radar = Radar(Depredador[x], Puntos, punto);
                        if (Principal == true)
                        {
                            DibujarRadar(punto, Animacion);
                            if(radar.X == 0 && radar.Y == 0)
                            {
                                Pen Direccion = new Pen(Color.DarkRed, 8);
                                DibujarDireccionOptima(Animacion, punto, Linea[Linea.Count - 1], Direccion);
                            }
                            else
                            {
                                ListaRadar.Items.Add(radar);
                                ListaRadar.Update();
                                Arista arista = EncontrarCamino(radar);
                                int Origen = Math.Abs(radar.X - arista.getVertexOrigen().getX()) + Math.Abs(radar.Y - arista.getVertexOrigen().getY());
                                int Destino = Math.Abs(radar.X - arista.getVertex().getX()) + Math.Abs(radar.Y - arista.getVertex().getY());
                                Pen DireccionPresa = new Pen(Color.DeepSkyBlue, 8);
                                if (Origen < Destino)
                                {
                                    DibujarDireccionOptima(Animacion, radar, new Point(arista.getVertexOrigen().getX(), arista.getVertexOrigen().getY()), DireccionPresa);
                                }
                                else
                                {
                                    DibujarDireccionOptima(Animacion, radar, new Point(arista.getVertex().getX(), arista.getVertex().getY()), DireccionPresa);
                                }
                                Pen Direccion = new Pen(Color.DarkRed, 8);
                                DibujarDireccionOptima(Animacion, punto, radar, Direccion);
                            }
                        }
                        Cazado(Puntos, punto,Depredador[x]);
                        DibujarCirculo(punto, BrochaDepredador, Animacion);
                        DibujarId(punto, BrochaID, Animacion, Depredador[x].getId());
                        Depredador[x].SetcontPunto(Depredador[x].GetcontPuntos() + 1);
                        if (Depredador[x].GetcontPuntos() >= Linea.Count)
                        {
                            Depredador[x].SetcontPunto(0);
                            Depredador[x].SetVerticeActual(Depredador[x].getCaminoActual()[y + 1]);
                            Depredador[x].SetcontAristas(Depredador[x].GetcontAristas()+1);
                            if (radar.X==0 && radar.Y == 0 && Depredador[x].GetPathDFS() == false)
                            {
                                List<Vertice> Visitados = new List<Vertice>();
                                Stack<Vertice> Pila = new Stack<Vertice>();
                                List<Vertice> CaminoNuevo = new List<Vertice>();
                                Pila.Push(Depredador[x].GetVerticeActual());
                                Visitados.Add(Depredador[x].GetVerticeActual());
                                CaminoNuevo.Add(Depredador[x].GetVerticeActual());
                                DFS(Pila, Visitados, CaminoNuevo);
                                Depredador[x].SetCaminoActual(CaminoNuevo);
                                Depredador[x].SetVerticeActual(CaminoNuevo[0]);
                                Depredador[x].SetcontAristas(0);
                                Depredador[x].SetPathDFS(true);
                            }
                            
                            if(radar.X !=0 && radar.Y != 0)
                            {
                                Arista arista = EncontrarCamino(radar);
                                if (arista.getVertexOrigen().Equals(Depredador[x].GetVerticeActual()))
                                {
                                    Dijkstra D = new Dijkstra(G, Depredador[x].GetVerticeActual(), arista.getVertex());
                                    D.GetCamino().Reverse();
                                    Depredador[x].SetCaminoActual(D.GetCamino());
                                    Depredador[x].SetVerticeActual(D.GetCamino()[0]);
                                }
                                else
                                {
                                    Dijkstra D = new Dijkstra(G, Depredador[x].GetVerticeActual(), arista.getVertexOrigen());
                                    D.GetCamino().Reverse();
                                    Depredador[x].SetCaminoActual(D.GetCamino());
                                    Depredador[x].SetVerticeActual(D.GetCamino()[0]);
                                }
                                Depredador[x].SetcontAristas(0);
                                Depredador[x].SetPathDFS(false);
                            }

                        }
                        if (Depredador[x].GetcontAristas() == Depredador[x].getCaminoActual().Count - 1)
                        {
                            Depredador[x].SetcontAristas(0);
                        }
                        x++;
                        if (x >= Depredador.Count)
                        {
                            x = 0;
                            pictureBox1.Refresh();
                            LimpiarBitmap(Animacion, Color.Transparent);
                            break;
                        }
                    }
                    Puntos.Clear();
                }
            }
            this.BtnAnimacion.Enabled = false;
        }

        void LimpiarBitmap(Bitmap bmp, Color c)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(c);
        }

        void DibujarId(Point punto, Brush Brocha, Bitmap bmp, int numero)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            string cadena = numero.ToString();
            graphics.DrawString(cadena, drawFont, Brocha, punto);
        }

        void DibujarRadar(Point punto, Bitmap bmp)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            Pen Chico = new Pen(Color.Red);
            Pen Mediano = new Pen(Color.Orange);
            Pen Grande = new Pen(Color.Yellow);
            graphics.DrawEllipse(Chico, punto.X - 50, punto.Y - 50, 100, 100);
            graphics.DrawEllipse(Mediano, punto.X - 125, punto.Y - 125, 250, 250);
            graphics.DrawEllipse(Grande, punto.X - 200, punto.Y - 200, 400, 400);
        }

        void Cazado(List<Point> Puntos,Point punto,Agente Depredador)
        {
            foreach (Point p in Puntos)
            {
                double Dentro = Math.Pow(p.X - punto.X, 2) + Math.Pow(p.Y - punto.Y, 2) - Math.Pow(16, 2);
                if (Dentro < 0)
                {
                    foreach (Agente agente in Presa)
                    {
                        if (agente.GetPuntoActual().Equals(p))
                        {
                            if (Depredador.GetAristaActual().Equals(agente.GetAristaActual()))
                            {
                                Presa.Remove(agente);
                                break;
                            }
                            if(Depredador.GetAristaActual().getVertex().Equals(agente.GetAristaActual().getVertexOrigen()) && Depredador.GetAristaActual().getVertexOrigen().Equals(agente.GetAristaActual().getVertex()))
                            {
                                Presa.Remove(agente);
                                break;
                            }
                        }
                    }
                }
            }
        }

        Point Radar(Agente Depredador, List<Point> Puntos, Point punto)
        {
            List<Point> Instantes = Depredador.GetInstantes();
            int i;
            for(i=0; i < 3; i++)
            {
                foreach(Point p in Puntos)
                {
                    if (i == 0)
                    {
                        double Dentro = Math.Pow(p.X - punto.X, 2) + Math.Pow(p.Y - punto.Y, 2);
                        if (Dentro <= Math.Pow(50, 2))
                            Instantes.Add(p);
                    }
                    if (i == 1)
                    {
                        double Dentro = Math.Pow(p.X - punto.X, 2) + Math.Pow(p.Y - punto.Y, 2);
                        if (Dentro <= Math.Pow(125, 2))
                            Instantes.Add(p);
                    }
                    if (i == 2)
                    {
                        double Dentro = Math.Pow(p.X - punto.X, 2) + Math.Pow(p.Y - punto.Y, 2);
                        if (Dentro <= Math.Pow(200, 2))
                            Instantes.Add(p);
                    }
                }
            }
            bool PrimerVertice = true;
            Point Cercano = new Point(0,0);
            if (Instantes.Count == 0)
            {
                return Cercano;
            }
            foreach (Point p in Instantes)
            {
                if (PrimerVertice == true)
                {
                    Cercano = p;
                    PrimerVertice = false;
                }
                else
                {
                    int DifCercano = Math.Abs(punto.X - Cercano.X) + Math.Abs(punto.Y - Cercano.Y);
                    int DifNuevo = Math.Abs(punto.X - p.X) + Math.Abs(punto.Y - p.X);
                    if (DifNuevo < DifCercano)
                        Cercano = p;
                }
            }
            Instantes.Clear();
            return Cercano;
        }

        Arista EncontrarCamino(Point Presa)
        {
            foreach(Vertice v in G.getLv())
            {
                foreach(Arista a in v.getLa())
                {
                    foreach(Point p in a.getLinea())
                    {
                        if (p.Equals(Presa))
                            return a;
                    }
                }
            }
            return null;
        }

        void DibujarDireccionOptima(Bitmap bmp,Point Origen,Point Destino,Pen Direccion)
        {
            List<Point> Lista = DireccionOptima(Origen, Destino);
            Graphics graphics = Graphics.FromImage(bmp);
            if(Lista.Count!=0)
                graphics.DrawLine(Direccion, Origen, Lista[Lista.Count/3]);
        }

        List<Point> DireccionOptima(Point PuntoInicio, Point PuntoFinal)
        {
            double m = ((double)PuntoFinal.Y - (double)PuntoInicio.Y) / ((double)PuntoFinal.X - (double)PuntoInicio.X);
            double b = (double)PuntoInicio.Y - (double)m * (double)PuntoInicio.X;
            double y_i, x_i;
            int inc = 1;
            Point Coordenadas;
            List<Point> Linea = new List<Point>();
            Coordenadas = new Point();
            if (Double.IsInfinity(m))
            {
                if (PuntoInicio.Y > PuntoFinal.Y)
                    inc = -1;
                for (y_i = PuntoInicio.Y; (int)y_i != PuntoFinal.Y; y_i += inc)
                {
                    x_i = PuntoInicio.X;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                }
                return Linea;
            }
            if (m <= 1 && m >= -1)
            {
                if (PuntoInicio.X > PuntoFinal.X)
                    inc = -1;
                for (x_i = PuntoInicio.X; (int)x_i != PuntoFinal.X; x_i += inc)
                {
                    y_i = m * x_i + b;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)Math.Round(y_i);
                    Linea.Add(Coordenadas);
                }
                return Linea;
            }
            else
            {
                if (PuntoInicio.Y > PuntoFinal.Y)
                    inc = -1;
                for (y_i = PuntoInicio.Y; (int)y_i != PuntoFinal.Y; y_i += inc)
                {
                    x_i = (y_i - b) / m;
                    Coordenadas.X = (int)Math.Round(x_i);
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                }
                return Linea;
            }
        }

        public void DFS(Stack<Vertice> Pila, List<Vertice> Visitados,List<Vertice> Camino)
        {
            Vertice v_act=Pila.Pop();
            foreach (Arista a in v_act.getLa())
            {
                bool Band = false;
                foreach (Vertice v in Visitados)
                {
                    if (v.getId() == a.getVertex().getId())
                    {
                        Band = true;
                        break;
                    }
                }
                if (Band == false)
                {
                    Visitados.Add(a.getVertex());
                    Pila.Push(a.getVertex());
                    Camino.Add(a.getVertex());
                    DFS(Pila, Visitados, Camino);
                    Camino.Add(a.getVertexOrigen());
                }
            }
        }
    }
}