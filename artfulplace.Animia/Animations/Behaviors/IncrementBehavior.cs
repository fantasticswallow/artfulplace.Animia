﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;

namespace artfulplace.Animia.Animations.Behaviors
{
	public class IncrementLeftBehavior : ArithmeticBase
	{
		public override void SetShapeValue(double time, Shape sh)
		{
			sh.IncrementLeft((float)Expression(convertToRate(time)));
		}
	}

	public class IncrementTopBehavior : ArithmeticBase
	{
		public override void SetShapeValue(double time, Shape sh)
		{
			sh.IncrementTop((float)Expression(convertToRate(time)));
		}
	}

	public class IncrementRotationBehavior : ArithmeticBase
	{
		public override void SetShapeValue(double time, Shape sh)
		{
			sh.IncrementRotation((float)Expression(convertToRate(time)));
		}
	}
}
