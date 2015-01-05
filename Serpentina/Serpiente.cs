using System;
using System.Collections;
using System.Collections.Generic;

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

//		enumDirecciónAbsoluta _dirección = enumDirecciónAbsoluta.Arriba;
		Structs.Par<int, int> _Pos = new Structs.Par<int, int>();

		Structs.ArregloCíclico<enumDirecciónAbsoluta> _Historial;

		/// <summary>
		/// Posición de la cabeza en el arreglo _Historial[];
		/// </summary>
//		int PosCabeza {
//			get {
//				return _Historial.
//			}
//		}

		/// <summary>
		/// La longitud máxima de la serpiente permitido por la longitud del arreglo.
		/// </summary>
		public int MaxLong {
			get
			{
				return  _Historial.MaxTamaño;
			}
		}

		/// <summary>
		/// La longitud actual de la serpiente.
		/// </summary>
		/// <value>The longitud.</value>
		public int Longitud {
			get {
				return _Historial.Tamaño;
			}
			set {
				_Historial.Tamaño = Math.Min (value, MaxLongitud);
			}
		}

		int _MaxLongitud = 1;

		/// <summary>
		/// Devuelve o establece la longitud máxima de la serpiente.
		/// </summary>
		/// <value>The max longitud.</value>
		public int MaxLongitud {
			get {
				return _MaxLongitud;
			}
			set {
				_MaxLongitud = Math.Min (Math.Max (value, 1), MaxLong);
				Longitud = Longitud;	// Recalcula la longitud dada esta nueva restricción.
			}
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
				return _Historial [0];
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
			

			switch (_Historial[i]) {
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
			ret._Historial = _Historial.Clone ();
			ret.Longitud = Longitud - i;
			return ret;
		}


		/// <summary>
		/// Devuelve el índice de la cola con respecto a la serpiente.
		/// </summary>
		/// <returns>The índice cola.</returns>
		public int ObtenerÍndiceCola ()
		{
			return 1 - Longitud;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.Serptiente"/> class.
		/// </summary>
		/// <param name="maxTamaño">Tamaño máximo de la serpiente</param>
		public Serpiente (int maxTamaño)
		{
			_Historial = new Structs.ArregloCíclico<enumDirecciónAbsoluta> (maxTamaño);
		}

		/// <summary>
		/// Avanza la serpiente hacia la dirección dir.
		/// </summary>
		/// <param name="dir">Dir.</param>
		public void Avanzar (enumDirecciónAbsoluta dir)
		{
			bool Despl = Longitud >= MaxLongitud;
			_Historial.Agrega (dir, Despl);
		}
	}
}