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
            s.clr.fgc = ConsoleColor.White;
            s2.clr.fgc = ConsoleColor.Cyan;

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
