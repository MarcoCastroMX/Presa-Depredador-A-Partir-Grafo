using System.Collections.Generic;

namespace ProyectoFinal
{
    class Dijkstra
    {
        Grafo G;
        List<Vertice> Camino;
        public Dijkstra(Grafo grafo, Vertice Origen,Vertice Destino)
        {
            G = grafo;
            List<ElementoDijktra> ArregloDijkstra = new List<ElementoDijktra>();
            List<ElementoDijktra> Desencolados = new List<ElementoDijktra>();
            Camino= new List<Vertice>();
            foreach(Vertice v in G.getLv())
            {
                ArregloDijkstra.Add(new ElementoDijktra(v));
            }
            foreach (ElementoDijktra v in ArregloDijkstra)
            {
                if (v.GetOrigen().Equals(Origen))
                {
                    v.SetDistanciaAcumulada(0);
                }    
            }
            while (!Solucion(ArregloDijkstra))
            {
                ArregloDijkstra.Sort((x, y) => x.GetDistanciaAcumulada().CompareTo(y.GetDistanciaAcumulada()));
                ElementoDijktra menor = ArregloDijkstra[0];
                ArregloDijkstra.RemoveAt(0);
                Desencolados.Add(menor);
                ActualizaVector(ArregloDijkstra, menor);
            }
            foreach (ElementoDijktra a in Desencolados)
            {
                if (a.GetOrigen() == Destino)
                {
                    ElementoDijktra Proveniente = a;
                    while(Proveniente != null)
                    {
                        Camino.Add(Proveniente.GetOrigen());
                        Proveniente = Proveniente.GetProveniente();
                    }
                }
            }
        }

        bool Solucion(List<ElementoDijktra> Arreglo)
        {
            if (Arreglo.Count != 0)
                return false;
            return true;
        }

        void ActualizaVector(List<ElementoDijktra> Arreglo, ElementoDijktra Menor)
        {
            foreach(Arista a in Menor.GetOrigen().getLa())
            {
                foreach(ElementoDijktra e in Arreglo)
                {
                    if (e.GetOrigen().Equals(a.getVertex()))
                    {
                        if (a.getPond() + Menor.GetDistanciaAcumulada() < e.GetDistanciaAcumulada())
                        {
                            e.SetDistanciaAcumulada(a.getPond() + Menor.GetDistanciaAcumulada());
                            e.SetProveniente(Menor);
                        }
                    }
                }
            }
        }

        public List<Vertice> GetCamino()
        {
            return Camino;
        }
    }

    class ElementoDijktra
    {
        Vertice Origen;
        double DistanciaAcumulada;
        ElementoDijktra Proveniente;

        public ElementoDijktra(Vertice inicio)
        {
            Origen = inicio;
            DistanciaAcumulada = double.PositiveInfinity;
            Proveniente = null;
        }
        public Vertice GetOrigen()
        {
            return Origen;
        }
        public double GetDistanciaAcumulada()
        {
            return DistanciaAcumulada;
        }
        public void SetDistanciaAcumulada(double Valor)
        {
            DistanciaAcumulada = Valor;
        }
        public ElementoDijktra GetProveniente()
        {
            return Proveniente;
        }
        public void SetProveniente(ElementoDijktra Valor)
        {
            Proveniente = Valor;
        }
    }
}
