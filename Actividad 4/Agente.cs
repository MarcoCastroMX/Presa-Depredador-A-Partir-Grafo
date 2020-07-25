using System.Collections.Generic;
using System.Drawing;

namespace ProyectoFinal
{
    public class Agente
    {
        List<Vertice> CaminoActual;
        List<Vertice> CaminoDFS;
        Vertice refOrigen;
        Vertice Destino;
        int id;
        int contAristas;
        int contPuntos;
        List<Point> Instantes = new List<Point>();
        Vertice VerticeActual;
        Arista AristaActual;
        Point PuntoActual;
        bool PathDFS;

        public Agente(Vertice Inicio,int numero,Vertice destino, List<Vertice> Camino){
            refOrigen = Inicio;
            contAristas = 0;
            contPuntos = 0;
            VerticeActual = Inicio;
            id = numero;
            Destino = destino;
            CaminoActual = Camino;
            CaminoDFS = Camino;
            PathDFS = false;
        }
        public override string ToString()
        {
            return string.Format("Origen={0}, Id={1}", refOrigen.getId(), id);
        }
        public void SetCaminoActual(List<Vertice> CaminoNuevo)
        {
            CaminoActual= CaminoNuevo;
        }
        public List<Vertice> getCaminoActual()
        {
            return CaminoActual;
        }
        public Vertice GetRefOrigen()
        {
            return refOrigen;
        }
        public void SetCaminoDFS(List<Vertice> CaminoNuevo)
        {
            CaminoDFS = CaminoNuevo;
        }
        public List<Vertice> getCaminoDFS()
        {
            return CaminoDFS;
        }
        public int GetcontAristas()
        {
            return contAristas;
        }
        public void SetcontAristas(int numero)
        {
            contAristas = numero;
        }
        public int GetcontPuntos()
        {
            return contPuntos;
        }
        public void SetcontPunto(int numero)
        {
            contPuntos = numero;
        }
        public int getId()
        {
            return id;
        }
        public Point GetPuntoActual()
        {
            return PuntoActual;
        }
        public void SetPuntoActual(Point punto)
        {
            PuntoActual = punto;
        }
        public Vertice GetVerticeActual()
        {
            return VerticeActual;
        }
        public void SetVerticeActual(Vertice vertice)
        {
            VerticeActual = vertice;
        }
        public Arista GetAristaActual()
        {
            return AristaActual;
        }
        public void SetAristaActual(Arista arista)
        {
            AristaActual = arista;
        }
        public List<Point> GetInstantes()
        {
            return Instantes;
        }
        public bool GetPathDFS()
        {
            return PathDFS;
        }
        public void SetPathDFS(bool value)
        {
            PathDFS = value;
        }
    }
}
