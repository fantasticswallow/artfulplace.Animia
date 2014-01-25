using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations.Behaviors
{
	public class ShapeCycleBehavior : ShapeBehaviorBase
	{
		public ShapeCycleBehavior()
		{
			IsDecrement = false;
			expression1 = x => firstValue - (x * x * (firstValue / 2)) - (Math.Sqrt(x) * (firstValue / 2));
			firstValue = -1.0f;
			IsReverse = false;
			IsHorizontal = true;
		}

		private float firstValue { get; set;}
		private float firstPosition { get; set; }
		private bool isExpanding { get; set;}

		public bool IsHorizontal { get; set;}
		private bool _isReverse = false;
		public bool IsReverse
		{
			get
			{
				return _isReverse;
			}
			set
			{
				_isReverse = value;
				if (_isReverse)
				{
					expression2 = leftForwardMargin;
				}
				else
				{
					expression2 = leftBackMargin;
				}
			}
		}

		public override void SetShapeValue(double time, Microsoft.Office.Interop.PowerPoint.Shape sh)
		{
			if (firstValue == -1.0f)
			{
				firstValue = IsHorizontal ? sh.Width : sh.Height;
				firstPosition = IsHorizontal ? sh.Left : sh.Top;
			}
			if (time >= FinishTime / 2)
			{
				isExpanding = true;
				IsDecrement = true;
				if (_isReverse)
				{
					expression2 = leftBackMargin;
				}
				else
				{
					expression2 = leftForwardMargin;
				}
			}
			var ctime = isExpanding ? time - (FinishTime / 2) : time;
			if (IsHorizontal)
			{
				sh.Width = (float)expression1(convertToRate(time));
				sh.Left = (float)expression2(convertToRate(time));
			}
			else
			{
				sh.Height = (float)expression1(convertToRate(time));
				sh.Top = (float)expression2(convertToRate(time));
			}
		}

		private Func<double, double> expression2 { get; set;}

		private double convertToRate(double elapsedTime)
		{
			var currentRate = elapsedTime / (FinishTime / 2);
			if (currentRate > 1.0)
			{
				currentRate = 1.0;
				if (elapsedTime >= FinishTime)
				{
					isCompleted = true;
				}
			}

			if (IsDecrement)
			{
				return 1.0 - currentRate;
			}
			return currentRate;
		}

		private Func<double, double> expression1 { get; set; }
		public bool IsDecrement { get; set; }
		public double FinishTime { get; set; }

		private double leftBackMargin(double time)
		{
			return firstPosition + (time * time * (firstValue / 2));
		}

		private double leftForwardMargin(double time)
		{
			return firstPosition + (Math.Sqrt(time) * (firstValue / 2));
		}
	}
}
