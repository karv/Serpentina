using System.Collections;
using System.Collections.Generic;
using CE.Console.Controls;

namespace Serpentina
{
	/// <summary>
	/// A collection of snakes.
	/// </summary>
	public class SnakeCollection : ISystem, IEnumerable<Snake>
	{
		/// <summary>
		/// The snakes.
		/// </summary>
		// TODO: To private and add requred methods (Add, etc)
		public List<Snake> Snakes;

		///
		public SnakeCollection ()
		{
			Snakes = new List<Snake> ();
		}

		IEnumerator<Snake> IEnumerable<Snake>.GetEnumerator ()
		{
			return Snakes.GetEnumerator ();
		}

		/// Initialize this system
		public void Initialize ()
		{
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return Snakes.GetEnumerator ();
		}
	}
}