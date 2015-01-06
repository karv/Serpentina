using System;

namespace Serpentina
{
	/// <summary>
	/// Agrega la posibilidad de dibujarse en consola a <see cref="Serpentina.Serpiente"/> .
	/// </summary>
	public class SerpienteConsola:Serpiente
	{
		public const char bg = ' ';
		public const char fg = 'x';
		public override void Avanzar (enumDirecciónAbsoluta dir)
		{
			Structs.Par<int, int> PosTmp = Pos (Longitud - 1); 	// Obtiene la posición de la cola.
			bool Despl = Longitud >= MaxLongitud;

			if (Despl) {	// Borrar sólo si se está desplazando y no creciendo.

				Console.CursorLeft = PosTmp.x;
				Console.CursorTop = PosTmp.y;
				Console.Write (bg);
			}

			base.Avanzar (dir);

			PosTmp = Pos (0); 	// Obtiene la posición de la cabeza

			Console.CursorLeft = PosTmp.x;
			Console.CursorTop = PosTmp.y;
			Console.Write (fg);


		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.SerpienteConsola"/> class.
		/// </summary>
		/// <param name="MaxTamaño">Tamaño máximo (por memoria).</param>
		/// <param name="x">Posición x inicial</param>
		/// <param name="y">Posición y inicial</param>
		public SerpienteConsola (int MaxTamaño, int x, int y):base(MaxTamaño,x,y) {}
			

	}
}

