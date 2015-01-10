using System;

namespace Serpentina
{
	/// <summary>
	/// Agrega la posibilidad de dibujarse en consola a <see cref="Serpentina.Serpiente"/> .
	/// </summary>
	public class SerpienteConsola:Serpiente
	{

		public Opciones.Color clr = new Opciones.Color();

		
		
		public override void Avanzar (enumDirecciónAbsoluta dir)
		{
			Structs.Par<int, int> PosTmp;
			bool Despl = Longitud >= MaxLongitud;

			if (Despl) {	// Borrar sólo si se está desplazando y no creciendo.

				PosTmp = Pos (Longitud); 	// Obtiene la posición de la cola.
				Console.CursorLeft = PosTmp.x;
				Console.CursorTop = PosTmp.y;
				Console.Write (clr.bg);
			}

			base.Avanzar (dir);

			PosTmp = Pos (0); 	// Obtiene la posición de la cabeza

			Console.CursorLeft = PosTmp.x;
			Console.CursorTop = PosTmp.y;
			Console.Write (clr.fg);


		}

		public void Dibujar ()
		{
			Structs.Par<int, int> PosTmp;
			for (int i = 0; i <= Longitud; i++) {
				PosTmp = Pos (i); 	// Obtiene la posición de la cabeza
				Console.CursorLeft = PosTmp.x;
				Console.CursorTop = PosTmp.y;
				Console.BackgroundColor = clr.bgc;
				Console.ForegroundColor = clr.fgc;
				Console.Write (clr.fg);
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Serpentina.SerpienteConsola"/> class.
		/// </summary>
		/// <param name="MaxTamaño">Tamaño máximo (por memoria).</param>
		/// <param name="x">Posición x inicial</param>
		/// <param name="y">Posición y inicial</param>
		public SerpienteConsola (int MaxTamaño, int x, int y):base(MaxTamaño,x,y) 
		{
			clr.OnCambio += Dibujar;
		}

	}
}

