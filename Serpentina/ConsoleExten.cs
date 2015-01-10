using System;

namespace ConsoleExt
{
	static class ConsoleExt
	{
		/// <summary>
		/// Pone un caracter en una posición en la Consola.
		/// </summary>
		/// <param name="c">Catarter.</param>
		/// <param name="Loc">Location.</param>
		/// <param name="clr">Color</param>
		public static void Poner (char c, Structs.Par<int, int> Loc, Opciones.Color clr)
		{
			Console.BackgroundColor = clr.bgc;
			Console.ForegroundColor = clr.fgc;
			Console.CursorLeft = Loc.x;

			Console.CursorTop = Loc.y;
			Console.Write (c);
		}
		public static void Poner (char c, int x, int y, Opciones.Color clr)
        {
            Poner(c, new Structs.Par<int, int>(x, y), clr);
        }

		/// <summary>
		/// Pone una cadena en una posición en la Consola.
		/// </summary>
		/// <param name="c">Catarter.</param>
		/// <param name="Loc">Location.</param>
		/// <param name="clr">Color</param>        
        public static void Poner(string s, Structs.Par<int, int> Loc, Opciones.Color clr)
        {
            Console.BackgroundColor = clr.bgc;
            Console.ForegroundColor = clr.fgc;
            Console.CursorLeft = Loc.x;

            Console.CursorTop = Loc.y;
            Console.Write(s);
        }

        /// <summary>
        /// Pone una cadena en una posición en la Consola.
        /// </summary>
        /// <param name="c">Catarter.</param>
        /// <param name="Loc">Location.</param>
        /// <param name="clr">Color</param>        
        public static void Poner(string s, int x, int y, Opciones.Color clr)
        {
            Poner(s, new Structs.Par<int, int>(x, y), clr);
        }
    }
}

