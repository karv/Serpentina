using System;

namespace Serpentina
{
	public class Serptiente
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

		enumDirecciónRelativa[] _Historial;
		/// <summary>
		/// Posición de la cabeza en el arreglo _dirección[];
		/// </summary>
		int PosCabeza = 0;

		readonly int MaxLong;

		int _Longitud = 1;

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
		/// 0 = cabeza, 1 = cuello, etc.
		/// </summary>
		/// <param name="i">The index.</param>
		public Tuple<int, int> Pos (int i) {
		if (i == 0)
			return Posición;
		if (i >= Longitud)
			throw new Exception ("Offbounds");

		Tuple<int, int> ret = Pos (i - 1);
		Serptiente tmp = Partir (i - 1);

			// TODO: Convvertir a dir relativa
			switch (_Historial[getIndexofPart(i)]) {
			case enumDirecciónAb.Arriba:
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
		/// OBtiene la serpiente hiecha de los primeros i partes de la actual.
		/// </summary>
		/// <param name="i">The index.</param>
		public Serptiente Partir (int i)
		{
			Serptiente ret = new Serptiente (MaxLong);
			ret._Historial = _Historial.Clone ();
			ret = PosCabeza = Pos;
			ret.Longitud = i;
			return ret;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.Serptiente"/> class.
		/// </summary>
		/// <param name="maxTamaño">Tamaño máximo de la serpiente</param>
		public Serptiente (int maxTamaño)
		{
			_Historial = new enumDirecciónRelativa[maxTamaño];
		}




		public void Avanzar (enumDirecciónRelativa dir)
		{
			PosCabeza = (PosCabeza + 1) % MaxLong;
			_Historial [PosCabeza] = dir;
		}
	}
}

