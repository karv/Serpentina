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
        public Rectángulo<int, int> Área;

        /// <summary>
        /// Ejecuta el juego.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                
            }
        }
        
    }
}
