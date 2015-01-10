using System;
using System.Collections.Generic;
using Structs;

namespace Serpentina
{
	/// <summary>
	/// Representa el universo de juego.
	/// </summary>
	public class Universo
	{
		public Opciones.Color bgColor = new Opciones.Color ();

		public event Action<Serpiente> OnMuerte;

		List<Serpiente> _Jugadores = new List<Serpiente> ();

		/// <summary>
		/// Devuelve la lista de jugadores.
		/// </summary>
		public List<Serpiente> Jugadores {
			get { return _Jugadores; }
		}

		/// <summary>
		/// Representa el área del juego.
		/// </summary>
		public RectanguloInt Area = new RectanguloInt ();

		/// <summary>
		/// Ejecuta el juego.
		/// </summary>
		public virtual void Run ()
		{
			Tiempo.Temporalizador Tempo = new Tiempo.Temporalizador ();  //El temporalizador del juego.
			Tempo.Timer = TimeSpan.FromSeconds (0.15);

			List<Serpiente> Muertos = new List<Serpiente> ();

			while (true) {
				Tempo.Reestablecer ();


				Serpiente.enumDirecciónAbsoluta dir;
				foreach (Serpiente x in Jugadores) {
					dir = x.DireccionActual;
					if (ObjetoEn (x.ObtenerPosiciónFutura (dir)) != null)
                        // Chocó con algo.
						Muertos.Add (x);
					else {
						x.Avanzar (this);

						// Mueren los que se salen
						if (!Area.PuntoDentro (x.Posicion))
							Muertos.Add (x);  // Promesa de muerte.
					}
				}

				// Matar a los que se les promete muerte
				foreach (Serpiente x in Muertos) {
					OnMuerte.Invoke (x);
					Jugadores.Remove (x);
				}
				Muertos.Clear ();                

				Tempo.EsperaFlag (AtrapaTeclas); //Espera a que pase un segundo desde el inicio del ciclo.
			}
		}

		/// <summary>
		/// Devuelve el objeto que se encuentra en una posición fija.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public object ObjetoEn (Structs.Par<int, int> p)
		{
			// ¿Es serpiente?
			foreach (Serpiente x in Jugadores) {
				if (x.ContienePos (p))
					return x;
			}
            
			return null;
		}

		/// <summary>
		/// Atrapa la entrada de teclas de consola.
		/// </summary>
		void AtrapaTeclas ()
		{
			ConsoleKeyInfo CKI;
			if (Console.KeyAvailable) {
				CKI = Console.ReadKey ();

				switch (CKI.Key) {
				case ConsoleKey.UpArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Arriba;
					break;
				case ConsoleKey.DownArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Abajo;
					break;
				case ConsoleKey.LeftArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Izquierda;
					break;
				case ConsoleKey.RightArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Derecha;
					break;
				}
			}
		}

		public Opciones.Color ColorBorde = new Opciones.Color ();

		/// <summary>
		/// Dibuja el área de juego.
		/// </summary>
		public void DibujaArea ()
		{

			for (int i = Area.x1 - 1; i <= Area.x2 + 1; i++) {
				for (int j = Area.y1 - 1; j <= Area.y2 + 1; j++) {
					ConsoleExt.ConsoleExt.Poner (i, j, bgColor);
				}
			}

			// Los bordes
			// Horizontales
			for (int i = Area.x1 - 1; i <= Area.x2 + 1; i++) {
				ConsoleExt.ConsoleExt.Poner (i, Area.y1 - 1, ColorBorde);
				ConsoleExt.ConsoleExt.Poner (i, Area.y2 + 1, ColorBorde);
			}

			// Verticales
			for (int i = Area.y1 - 1; i <=  Area.y2 + 1; i++) {
				ConsoleExt.ConsoleExt.Poner (Area.x1 - 1, i, ColorBorde);
				ConsoleExt.ConsoleExt.Poner (Area.x2 + 1, i, ColorBorde);
			}
		}

		public void Dibuja ()
		{
			DibujaArea ();
			foreach (Serpiente x in Jugadores) {
				x.Dibujar ();
			}
		}

		void AlMorir (Serpiente x)
		{
			x.Borrar (bgColor);     // Debe marcar error si no es SerpienteConsola.
			ConsoleExt.ConsoleExt.Poner (string.Format ("Muere {0}.", x), 1, 20, x.clr);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.UniversoConsola"/> class.
		/// Ajusta el <c>Área</c> al tamaño actual de la consola.
		/// </summary>
		public Universo ()
		{
			ColorBorde.OnCambio += DibujaArea;
			OnMuerte += AlMorir;
			Area = new Structs.RectanguloInt (1, 1, Console.BufferWidth - 2, Console.BufferHeight - 2);
		}
	}
}
