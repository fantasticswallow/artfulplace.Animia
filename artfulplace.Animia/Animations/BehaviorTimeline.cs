using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations
{
	public class BehaviorTimeline : ITimeline
	{
		public IBehavior[] Behavior { get; set;}

		public bool IsFinished { get; set;}

		public object TargetObject { get; set;}
		
		public void timerUpdate(double elapsedSeconds)
		{
			var target = Behavior.Where(x => x.StartTime <= elapsedSeconds).Where(x => !x.IsCompleted);
			foreach (var b in target)
			{
				b.SetValue(elapsedSeconds, TargetObject);
			}
			if (Behavior.All(_ => _.IsCompleted))
			{
				IsFinished = true;
			}
		}

		public void SetDefaultValue()
		{
			var target = Behavior.Where(x => x.StartTime < 0.0);
			foreach (var b in target)
			{
				b.SetValue(-1.0, TargetObject);
			}
			IsFinished = false;
		}
	}
}
