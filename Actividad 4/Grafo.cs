using System.Collections.Generic;
using System.Drawing;

namespace ProyectoFinal
{
	public class Grafo{
		List<Vertice> lv;
		public Grafo(){
			lv= new List<Vertice>();
		}
		public List<Vertice> getLv(){
			return lv;
		}
		public void setLv(List<Vertice> lv){
			this.lv=lv;
		}
	}
	public class Vertice
	{
		List<Arista> la;
		int x;
		int y;
		int r;
		int id;
		public Vertice(int x, int y, int r, int id)
		{
			this.x=x;this.y=y;this.r=r;this.id=id;
			this.la = new List<Arista>();
		}
		public override string ToString()
		{
			return string.Format("X={0}, Y={1}, R={2}, Id={3}", x, y, r, id);
		}
		public void addArista(Vertice vDest, double pond, Vertice vOrigen, List<Point> Lista)
        {
			Arista e = new Arista(vDest, pond,vOrigen,Lista);
            la.Add(e);
            
		}
		public int getX(){
			return x;
		}
		public int getY(){
			return y;
		}
		public int getR(){
			return r;
		}
		public List<Arista> getLa(){
			return la;
		}
		public int getId(){
			return id;
		}
	}
	
	public class Arista{
		Vertice refDest;
        Vertice refOrigen;
        List<Point> linea;
		int id;
		double pond;
		
		public Arista(Vertice vDest, double pond,Vertice vOrigen,List<Point> Lista){
			refDest = vDest;
            refOrigen = vOrigen;
            linea = Lista;
			id = vDest.getId();
			this.pond = pond;
		}
        public List<Point> getLinea(){
            return linea;
        }
		public Vertice getVertex(){
			return refDest;
		}
        public Vertice getVertexOrigen(){
            return refOrigen;
        }
		public int getId(){
			return id;
		}
		public double getPond(){
			return pond;
		}
	}
}
