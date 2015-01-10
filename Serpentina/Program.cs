using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Serpiente s = new Serpiente (10, 10, 10);
            Serpiente s2 = new Serpiente (10, 10, 100);

			Console.CursorVisible = false;

			s.MaxLongitud = 7;
            Universo U = new Universo();
//            U.Area = new Structs.RectanguloInt(1, 1, 40, 40);

            s.Posicion.x = 3;
            s.Posicion.y = 3;
            s2.Posicion.x = 7;
            s2.Posicion.y = 3;

            s.ClrCola.fgc = ConsoleColor.White;
            s2.ClrCola.fgc = ConsoleColor.Cyan;

			s.ClrCabeza.fgc = ConsoleColor.White;
			s2.ClrCabeza.fgc = ConsoleColor.Cyan;

			s.ClrCabeza.bgc = ConsoleColor.Black;
			s2.ClrCabeza.bgc = ConsoleColor.Black;

			s.ClrCola.bgc = ConsoleColor.Black;
			s2.ClrCola.bgc = ConsoleColor.Black;

			s.ClrCabeza.chr = 'o';
			s2.ClrCabeza.chr = 'o';

			s.ClrCola.chr = '#';
			s2.ClrCola.chr = '#';

			U.bgColor.bgc = ConsoleColor.Black;
			U.bgColor.chr = ' ';
			U.bgColor.fgc = ConsoleColor.Red;

            U.Jugadores.Add(s);
            U.Jugadores.Add(s2);

            U.Dibuja();

            U.Run();
		}
	}
}
