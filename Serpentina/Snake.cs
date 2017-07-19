using CE;
using CE.Collections;
using CE.Color;
using System;

namespace Serpentina
{
	public class Snake
	{
		ColoredChar _headChar;
		ColoredChar _bodyChar;
		MoveDir _currentHeadDir;

		ModulusList<Point> _bodyPoints;

		TimeSpan _advanceTime;
		TimeSpan _accumulatedAdvTime;
	}
}