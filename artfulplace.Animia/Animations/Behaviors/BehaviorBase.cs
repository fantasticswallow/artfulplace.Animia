using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations.Behaviors
{
	/// <summary>
	/// IBehavior実装のベースとなるクラス
	/// </summary>
	public abstract class BehaviorBase : IBehavior
	{
		public abstract void SetValue(double time, object sh);

		public bool IsCompleted
		{
			get { return isCompleted; }
		}

		protected bool isCompleted = false;

		public double StartTime { get; set;}
		
	}
}
