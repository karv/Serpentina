using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Serpiente s = new Serpiente (10);
            Universo U = new Universo();
            U.�rea = new Structs.Rect�nguloInt(0, 0, 40, 40);

            s.Posici�n.x = 3;
            s.Posici�n.y = 3;

            U.Jugadores.Add(s);

            U.Run();

			Console.WriteLine ("Hello World!");
		}
	}
}
