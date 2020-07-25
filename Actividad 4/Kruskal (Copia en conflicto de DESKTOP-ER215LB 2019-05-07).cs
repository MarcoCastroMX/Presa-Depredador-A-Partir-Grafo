using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_4
{
    class Kruskal
    {
        List<Vertice> lv = new List<Vertice>();
        List<List<Vertice>> ComponentesConexos = new List<List<Vertice>>();
        List<Arista> Camino = new List<Arista>();
        int Grafos = 1;

        public Kruskal(Grafo grafo)
        {
            lv = grafo.getLv();
            List<Arista> Candidatos = new List<Arista>();
            List<Arista> Prometedor = new List<Arista>();
            foreach (Vertice v in lv)
            {
                foreach(Arista a in v.getLa())
                {
                    Candidatos.Add(a);
                }
            }
            for(int i=0;i<lv.Count;i++)
            {
                List<Vertice> CC = new List<Vertice>();
                ComponentesConexos.Add(CC);
            }
            int Indice = 0;
            foreach (List<Vertice> l in ComponentesConexos)
            {
                l.Add(lv[Indice]);
                Indice++;
            }
            while (!Solucion(Prometedor))
            {
                Arista Elegida;
                Elegida = Seleccion(Candidatos);
                if (Elegida == null)
                {
                    foreach(Arista a in Prometedor)
                    {
                        System.Diagnostics.Debug.WriteLine(a.getVertexOrigen().getId());
                    }
                }
                else
                {
                    Vertice[] Menor = new Vertice[2];
                    Menor[0] = Elegida.getVertexOrigen();
                    Menor[1] = Elegida.getVertex();
                    List<Vertice> Origen = BuscaCC(Menor[0]);
                    List<Vertice> Destino = BuscaCC(Menor[1]);
                    if (Origen != Destino)
                    {
                        Prometedor.Add(Elegida);
                        UnirCC(Origen, Destino);
                    }
                }
            }
            Camino = Prometedor;
            Grafos = ComponentesConexos.Count;
        }

        bool Solucion(List<Arista> Prometedor)
        {
            if (Prometedor.Count == lv.Count - 1)
                return true;
            return false;
        }

        Arista Seleccion(List<Arista> Candidatos)
        {
            double Menor = 0;
            Arista AristaMenor = null;
            bool Primero = false;
            foreach (Arista a in Candidatos)
            {
                if (Primero == false)
                {
                    Menor = a.getPond();
                    AristaMenor = a;
                    Primero = true;
                }
                if (a.getPond() < Menor)
                {
                    Menor = a.getPond();
                    AristaMenor = a;
                }
            }
            Candidatos.Remove(AristaMenor);
            return AristaMenor;
        }

        List<Vertice> BuscaCC(Vertice vertice){
            foreach(List<Vertice> l in ComponentesConexos)
            {
                foreach(Vertice v in l)
                {
                    if (v == vertice)
                        return l;
                }
            }
            return null;
        }

        void UnirCC(List<Vertice> Origen, List<Vertice> Destino)
        {
            foreach(Vertice v in Destino)
            {
                Origen.Add(v);
            }
            ComponentesConexos.Remove(Destino);
        }

        public List<Arista> getCamino()
        {
            return Camino;
        }

        public int getSubgrafos()
        {
            return Grafos;
        }
    }
}
