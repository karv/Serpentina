using System;
using System.Collections.Generic;

namespace Serpentina
{
	public class SnakeCollision
	{
		public readonly bool AnyCollision;
		public readonly Snake HeadCollider;
		public readonly Snake PassiveCollider;
	}

	public static class SnakeCollider
	{
		public static SnakeCollision GetCollision (ICollection<Snake> snakes)
		{
			throw new NotImplementedException ();
		}
	}
}