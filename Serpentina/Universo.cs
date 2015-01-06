using System;
using System.Collections.Generic;
using Structs;

namespace Serpentina
{
    /// <summary>
    /// Representa el universo de juego.
    /// </summary>
    public class Universo
    {
        List<Serpiente> _Jugadores = new List<Serpiente>();
        
        /// <summary>
        /// Devuelve la lista de jugadores.
        /// </summary>
        public List<Serpiente> Jugadores
        {
            get { return _Jugadores; }
        }

        /// <summary>
        /// Representa el área del juego.
        /// </summary>
        public RectánguloInt Área = new RectánguloInt();

        /// <summary>
        /// Ejecuta el juego.
        /// </summary>
        public void Run()
        {
            Tiempo.Temporalizador Tempo = new Tiempo.Temporalizador();  //El temporalizador del juego.
            Tempo.Timer = TimeSpan.FromSeconds(1);

            List<Serpiente> Muertos = new List<Serpiente>();

            while (true)
            {
                Tempo.Reestablecer();

                foreach (Serpiente x in Jugadores)
                {
                    x.Avanzar(Serpiente.enumDirecciónAbsoluta.Derecha);

                    Console.WriteLine(x.Posición.ToString());

                    // Mueren los que se salen
                    if (!Área.PuntoDentro(x.Posición)) Muertos.Add(x);  // Promesa de muerte.
                }

                // Matar a los que se les promete muerte
                foreach (Serpiente x in Muertos)
                {
                    Jugadores.Remove(x);
                    Console.WriteLine("Muere " + x.ToString());

                }
                Muertos.Clear();

                Tempo.EsperaFlag(); //Espera a que pase un segundo desde el inicio del ciclo.
            }
        }
        
    }
}
