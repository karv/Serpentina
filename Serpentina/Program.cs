using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SerpienteConsola s = new SerpienteConsola (10, 10, 10);

			s.MaxLongitud = 7;

			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Izquierda);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Abajo);

			Console.WriteLine (s.Pos (0));
			Console.WriteLine (s.Pos (1));
			Console.WriteLine (s.Pos (2));
			Console.WriteLine (s.Pos (3));
				

			Console.ReadLine ();



		}
	}
}
