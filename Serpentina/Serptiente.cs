using System;

namespace Serpentina
{
	public class Serptiente
	{
		public enum enumDirecciónAbsoluta
		{
			Arriba,
			Izquierda,
			Abajo,
			Derecha
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

		int[] _Historial;
		int PosCabeza = 0;

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
		/// Initializes a new instance of the <see cref="Serpentina.Serptiente"/> class.
		/// </summary>
		/// <param name="maxTamaño">Tamaño máximo de la serpiente</param>
		public Serptiente (int maxTamaño)
		{
			_Historial = new int[maxTamaño];
		}
	}
}

