using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations
{
	public interface ITimeline
	{
		bool IsFinished { get; set; }
		object TargetObject { get; set;}

		void timerUpdate(double elapsedSeconds);

		void SetDefaultValue();
	}
}
