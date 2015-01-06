using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SerpienteConsola s = new SerpienteConsola (10, 10, 10);

			s.MaxLongitud = 7;

			s.Dibujar ();

			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);	

			Console.ReadLine ();



		}
	}
}
