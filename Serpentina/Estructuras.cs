using System;

namespace Structs
{
	public class Par <S, T>
	{
		public S x;
		public T y;

		public override bool Equals (object obj)
		{
			if (obj is Par<S, T>) {
				Par <S, T> cmp = (Par<S, T>)obj;
				return x.Equals (cmp.x) && y.Equals (cmp.y);
			}
			return false;
		}
		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public override string ToString ()
		{
			return string.Format ("({0}, {1})", x.ToString (), y.ToString ());
		}

		public Par (S a, T b)
		{
			x = a;
			y = b;
		}
        public Par()
        {
        }
	}

    public class Rectangulo<S, T> : Par<Par<S, T>,Par<S,T>>
    {
        public S x1
        {
            get { return x.x; }
        }
        public S x2
        {
            get { return y.x; }
        }
        public T y1
        {
            get { return x.y; }
        }
        public T y2
        {
            get { return y.y; }
        }

        /// <summary>
        /// Crea una instancia a partir de sus esquinas opestas.
        /// </summary>
        public Rectangulo(S nx1, T ny1, S nx2, T ny2) : base(new Par<S,T>(nx1, ny1), new Par<S,T> (nx2, ny2)) {}
        public Rectangulo() : base(new Par<S,T>(), new Par<S,T>()) {}

    }
    /// <summary>
    /// Representa un rectángulo de coordenadas enteras.
    /// </summary>
    public class RectanguloInt : Rectangulo<int, int>
    {
        /// <summary>
        /// Devuelve <c>true</c> si un punto específico está dentro del rectángulo
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool PuntoDentro(Par<int, int> p)
        {
            return (x1 <= p.x && p.x <= x2 && y1 <= p.y && p.y <= y2);
        }

        //ctors
        public RectanguloInt(int nx1, int ny1, int nx2, int ny2) : base (nx1, ny1, nx2, ny2){}
        public RectanguloInt() {}
    }

}

