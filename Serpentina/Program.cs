using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SerpienteConsola s = new SerpienteConsola (10, 10, 10);
            SerpienteConsola s2 = new SerpienteConsola(10, 10, 100);

			s.MaxLongitud = 7;
            UniversoConsola U = new UniversoConsola();
            U.Area = new Structs.RectanguloInt(1, 1, 40, 40);

            s.Posici�n.x = 3;
            s.Posici�n.y = 3;
            s2.Posici�n.x = 7;
            s2.Posici�n.y = 3;
            s.clr.fgc = ConsoleColor.White;
            s2.clr.fgc = ConsoleColor.Cyan;

            U.Jugadores.Add(s);
            U.Jugadores.Add(s2);

            U.Dibuja();

            U.Run();
		}
	}
}
