using System;
using System.Collections;
using System.Collections.Generic;

namespace Structs
{
	/// <summary>
	/// Arreglo cíclico.
	/// </summary>
	public class ArregloCíclico <T> : IEnumerable <T>
	{	
		/// <summary>
		/// Posición de la cabecera
		/// </summary>
		int _Pos = 0;

		/// <summary>
		/// Tamaño actual del arreglo.
		/// </summary>
		int _Tamaño = 0;

		/// <summary>
		/// El tamaño del arreglo
		/// </summary>
		/// <value>The tamaño.</value>
		public int Tamaño {
			get {
				return _Tamaño;
			}
			set {
				_Tamaño = Math.Max (Math.Min (value, MaxTamaño), 0);
			}
		}

		/// <summary>
		/// Devuelve el tamaño maximo de este arreglo.
		/// </summary>
		public readonly int MaxTamaño;

		/// <summary>
		/// El arreglo lineal.
		/// </summary>
		T[] _Data;

		/// <summary>
		/// Initializes a new instance of the <see cref="Structs.ArregloCíclico`1"/> class.
		/// </summary>
		/// <param name="TamañoMáximo">Tamaño máximo.</param>
		public ArregloCíclico (int TamañoMáximo)
		{
			MaxTamaño = TamañoMáximo;
			_Data = new T[TamañoMáximo];
			// ArregloCíclico<T> r = new ArregloCíclico<T> ();
		}

		// IEnumerable <T>
		public IEnumerator<T> GetEnumerator()
		{
			// Volcar _Data en otro T[]
			T[] tmp = new T[MaxTamaño];
			for (int i = 0; i < Tamaño; i++) {
				int j = (i + _Pos) % MaxTamaño;
				tmp [i] = _Data [j];
			}
			return (IEnumerator<T>)tmp.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			// Volcar _Data en otro T[]
			T[] tmp = new T[MaxTamaño];
			for (int i = 0; i < Tamaño; i++) {
				int j = (i + _Pos) % MaxTamaño;
				tmp [i] = _Data [j];
			}
			return tmp.GetEnumerator ();
		}
		// Acceso.

		public T this[int i]
		{
			get {
				int j = (i + _Pos) % MaxTamaño;
				return _Data [j];
			}
			set {
				int j = (i + _Pos) % MaxTamaño;
				_Data [j] = value;
			}		
		}
	}
}
