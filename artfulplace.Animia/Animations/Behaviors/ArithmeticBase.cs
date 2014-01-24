using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations.Behaviors
{
	public abstract class ArithmeticBase : ShapeBehaviorBase
	{
		protected double convertToRate(double elapsedTime)
		{
			var currentRate = elapsedTime / FinishTime;
			if (currentRate > 1.0)
			{
				currentRate = 1.0;
				isCompleted = true;
			}

			if (IsDecrement)
			{
				return 1.0 - currentRate;
			}
			return currentRate;
		}

		public Func<double, double> Expression { get; set; }
		public bool IsDecrement { get; set; }
		public double FinishTime { get; set; }
	}
}
