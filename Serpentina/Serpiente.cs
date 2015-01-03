using System;

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
		Tuple<int, int> _Pos;

		// TODO Cambiar historial de dir relativa a absoluta;  o bien, agragar variable que dice hacia dónde absolutamente se dirige la cabeza.
		// De lo contrario, girar es un invariante.

		enumDirecciónRelativa[] _Historial;
		/// <summary>
		/// Posición de la cabeza en el arreglo _dirección[];
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

		public int getIndexofPart (int i) {
			return PosCabeza + i % MaxLong;
		}

		/// <summary>
		/// Devuelve la posición de la cabeza de la serpiente.
		/// </summary>
		/// <value>The posición.</value>
		public Tuple<int, int> Posición {
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
				return _dirección;
			}
		}

		/// <summary>
		/// Devuelve la posición de una parte del cuerpo de la serpiente.
		/// i = 0 => cabeza, i = 1 => cuello, etc.
		/// </summary>
		/// <param name="i">The index.</param>
		public Tuple<int, int> Pos (int i) {
			if (i == 0)
				return Posición;
			if (i >= Longitud)
				throw new IndexOutOfRangeException();

			Tuple<int, int> ret = Pos (i - 1);
			Serpiente tmp = Cola (i - 1);
			enumDirecciónAbsoluta da = tmp.DirecciónAbsoluta;
			

			// TODO: Convvertir a dir relativa
			switch (_Historial[getIndexofPart(i)]) {
			case enumDirecciónAbsoluta.Arriba:
				ret.Item2 ++;
				break;
			case enumDirecciónAbsoluta.Abajo:
				ret.Item2 --;
				break;
			case enumDirecciónAbsoluta.Izquierda:
				ret.Item1 ++;
				break;
			case enumDirecciónAbsoluta.Derecha:
				ret.Item1 --;
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
			ret._Historial = (enumDirecciónRelativa[])_Historial.Clone ();
			ret.PosCabeza = i;
			ret.Longitud = Longitud - i;
			return ret;
		}



		public int ObtenerÍndiceCola ()
		{
			return getIndexofPart (1 - Longitud);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.Serptiente"/> class.
		/// </summary>
		/// <param name="maxTamaño">Tamaño máximo de la serpiente</param>
		public Serpiente (int maxTamaño)
		{
			_Historial = new enumDirecciónRelativa[maxTamaño];
		}

		/// <summary>
		/// Avanza la serpiente hacia la dirección dir.
		/// </summary>
		/// <param name="dir">Dir.</param>
		public void Avanzar (enumDirecciónRelativa dir)
		{
			PosCabeza = (PosCabeza + 1) % MaxLong;
			_Historial [PosCabeza] = dir;
		}
	}
}

