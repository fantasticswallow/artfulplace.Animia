using System;

namespace artfulplace.Animia.Animations
{

	/// <summary>
	/// 算術演算に対応したアニメーションを行うための基本クラス
	/// </summary>
	public abstract class ArithmeticAnimation : IAnimation		
	{
		public virtual object CurrentValue(double elapsedTime)
		{
			var rate = convertToRate(elapsedTime);
			var res = this.Expression(rate);
			return Convert.ChangeType(res,valueType);
		}

		private double convertToRate(double elapsedTime)
		{
			var currentRate = elapsedTime / FinishTime;
			if (currentRate > 1.0)
			{
				currentRate = 1.0;
				_isCompleted = true;
			}

			if (IsDecrement)
			{
				return 1.0 - currentRate;
			}
			return currentRate;
		}

		public Func<double, double> Expression { get; set;}
		public bool IsDecrement { get; set;}
		public double FinishTime { get; set;}

		private bool _isCompleted = false;

		public bool IsCompleted
		{
			get { return _isCompleted; }
		}

		protected virtual Type valueType
		{
			get { return typeof(double); }
		}

		public double StartTime { get; set;}
	}
}
