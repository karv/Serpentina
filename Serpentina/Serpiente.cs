using System;

namespace Structs
{
	public struct Par <S, T>
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
	}
}
namespace Serpentina
{
	public class Serpiente
	{
		public enum enumDirecciónAbsoluta
		{
			Arriba = 1,
			Izquierda = -2,
			Abajo = -1,
			Derecha = 2
		}

		public enum enumDirecciónRelativa
		{
			Derecho = 0,
			Izquierda = -1,
			Derecha = 1,
			Atrás = 2
		}

		enumDirecciónAbsoluta _dirección = enumDirecciónAbsoluta.Arriba;
		Structs.Par<int, int> _Pos;

		enumDirecciónAbsoluta[] _Historial;
		/// <summary>
		/// Posición de la cabeza en el arreglo _Historial[];
		/// </summary>
		int PosCabeza = 0;

		readonly int MaxLong;

		int _Longitud = 1;
		/// <summary>
		/// La longitud actual de la serpiente.
		/// </summary>
		/// <value>The longitud.</value>
		public int Longitud {
			get {
				return  
					_Longitud;
			}
			set {
				_Longitud = Math.Min (Math.Max (value, 1), MaxLong);
			}
		}

		/// <summary>
		/// Devuelve el índice de la i-ésima parte de la serpiente.
		/// </summary>
		/// <returns>The índice parte.</returns>
		/// <param name="i">Índice de la parte con respecto a la (cabeza de la) serpiente</param>
		public int ObtenerÍndiceParte (int i) {
			return PosCabeza + i % MaxLong;
		}

		/// <summary>
		/// Devuelve la posición de la cabeza de la serpiente.
		/// </summary>
		/// <value>The posición.</value>
		public Structs.Par<int, int> Posición {
			get {
				return _Pos;
			}
		}
		/// <summary>
		/// Devuelve la dirección absoluta de la cabeza.
		/// </summary>
		/// <value>The dirección absoluta.</value>
		public enumDirecciónAbsoluta DirecciónAbsoluta {
			get {
				return _Historial [PosCabeza];
			}
		}

		/// <summary>
		/// Devuelve la posición de una parte del cuerpo de la serpiente.
		/// i = 0 => cabeza, i = 1 => cuello, etc.
		/// </summary>
		/// <param name="i">The index.</param>
		public Structs.Par<int, int> Pos (int i) {
			if (i == 0)
				return Posición;
			if (i >= Longitud)
				throw new IndexOutOfRangeException();

			Structs.Par<int, int> ret = Pos (i - 1);
			Serpiente tmp = Cola (i - 1);
			enumDirecciónAbsoluta da = tmp.DirecciónAbsoluta;
			

			switch (_Historial[ObtenerÍndiceParte(i)]) {
			case enumDirecciónAbsoluta.Arriba:
				ret.y ++;
				break;
			case enumDirecciónAbsoluta.Abajo:
				ret.y --;
				break;
			case enumDirecciónAbsoluta.Izquierda:
				ret.x ++;
				break;
			case enumDirecciónAbsoluta.Derecha:
				ret.x --;
				break;
			}
			return ret;
		}

		/// <summary>
		/// Obtiene la serpiente hecha de los primeros i partes de la actual.
		/// Obtiene la cola de la serpiente.
		/// </summary>
		/// <param name="i">Índice de la cabeza de la nueva serpiente.</param>
		public Serpiente Cola (int i)
		{
			Serpiente ret = new Serpiente (MaxLong);
			ret._Historial = (enumDirecciónAbsoluta[])_Historial.Clone ();
			ret.PosCabeza = i;
			ret.Longitud = Longitud - i;
			return ret;
		}


		/// <summary>
		/// Devuelve el índice de la cola con respecto a la serpiente.
		/// </summary>
		/// <returns>The índice cola.</returns>
		public int ObtenerÍndiceCola ()
		{
			return ObtenerÍndiceParte (1 - Longitud);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.Serptiente"/> class.
		/// </summary>
		/// <param name="maxTamaño">Tamaño máximo de la serpiente</param>
		public Serpiente (int maxTamaño)
		{
			_Historial = new enumDirecciónAbsoluta[maxTamaño];
			MaxLong = maxTamaño;
		}

		/// <summary>
		/// Avanza la serpiente hacia la dirección dir.
		/// </summary>
		/// <param name="dir">Dir.</param>
		public void Avanzar (enumDirecciónAbsoluta dir)
		{
			PosCabeza = (PosCabeza + 1) % MaxLong;
			_Historial [PosCabeza] = dir;
		}
	}
}

