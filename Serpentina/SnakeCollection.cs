using System.Collections;
using System.Collections.Generic;
using CE.Console.Controls;

namespace Serpentina
{
	/// <summary>
	/// The game state
	/// </summary>
	public class SnakeCollection : ISystem, IEnumerable<Snake>
	{
		public List<Snake> Snakes;

		public SnakeCollection ()
		{
			Snakes = new List<Snake> ();
		}

		IEnumerator<Snake> IEnumerable<Snake>.GetEnumerator ()
		{
			return Snakes.GetEnumerator ();
		}

		public void Initialize ()
		{
		}

		public void Update () { }

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return Snakes.GetEnumerator ();
		}
	}
}