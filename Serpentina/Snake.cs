using System;
using CE;
using CE.Collections;
using CE.Color;
using System.Linq;

namespace Serpentina
{
	public class Snake
	{
		ColoredChar _headChar;
		ColoredChar _bodyChar;
		MoveDir _currentHeadDir;
		SnakeTail _bodyPoints;
		TimeSpan _advanceTime;
		TimeSpan _accumulatedAdvTime;
		bool _isAlive = true;

		public TimeSpan AdvanceTime { get => _advanceTime; set => _advanceTime = value; }
		public TimeSpan AccumulatedAdvTime { get => _accumulatedAdvTime; set => _accumulatedAdvTime = value; }
		public SnakeTail BodyPoints { get => _bodyPoints; set => _bodyPoints = value; }
		public MoveDir CurrentHeadDir { get => _currentHeadDir; set => _currentHeadDir = value; }
		public ColoredChar BodyChar { get => _bodyChar; set => _bodyChar = value; }
		public ColoredChar HeadChar { get => _headChar; set => _headChar = value; }
		public Point HeadLocation { get { return _bodyPoints[0]; } }
		public Point OverheadLocation { get { return HeadLocation + _currentHeadDir.ToPoint (); } }
		public bool IsAlive { get => _isAlive; }

		/// <summary>
		/// Accumulates the specified time it <see cref="AccumulatedAdvTime"/>
		/// </summary>
		/// <returns><c>true</c>, if shoudl execute move. <c>false</c> otherwise.</returns>
		/// <param name="time">Time.</param>
		public bool PassTime (TimeSpan time)
		{
			AccumulatedAdvTime += time;
			return AccumulatedAdvTime >= AdvanceTime;
		}

		public bool ContainsPoint (Point p)
		{
			return _bodyPoints.Contains (p);
		}

		public void Die ()
		{
			_isAlive = false;
		}
	}
}