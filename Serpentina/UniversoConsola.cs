using System;

namespace Serpentina
{
	public class UniversoConsola:Universo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.UniversoConsola"/> class.
		/// Ajusta el <c>Área</c> al tamaño actual de la consola.
		/// </summary>
		public UniversoConsola ()
		{
			ColorBorde.OnCambio += DibujaArea;
			Area = new Structs.RectanguloInt (1, 1, Console.BufferWidth - 2, Console.BufferHeight - 2);
		}

		public Opciones.Color ColorBorde = new Opciones.Color();

		/// <summary>
		/// Dibuja el área de juego.
		/// </summary>
		public void DibujaArea ()
		{
			// Los bordes
			// Horizontales
			for (int i = Area.x1 - 1; i <= Area.x2 + 1; i++) {
				ConsoleExt.ConsoleExt.Poner (ColorBorde.fg, new Structs.Par<int, int> (i, Area.y1 - 1), ColorBorde);
				ConsoleExt.ConsoleExt.Poner (ColorBorde.fg, new Structs.Par<int, int> (i, Area.y2 + 1), ColorBorde);
			}

			// Verticales
			for (int i = Area.y1 - 1; i <=  Area.y2 + 1; i++) {
				ConsoleExt.ConsoleExt.Poner (ColorBorde.fg, new Structs.Par<int, int> (Area.x1 - 1, i), ColorBorde);
				ConsoleExt.ConsoleExt.Poner (ColorBorde.fg, new Structs.Par<int, int> (Area.x2 + 1, i), ColorBorde);
			}
		}

		public void Dibuja ()
		{
			DibujaArea ();
			foreach (SerpienteConsola x in Jugadores) {
				x.Dibujar ();
			}
		}
	}
}

