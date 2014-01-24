using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations
{
	public interface IAnimation
	{
		object CurrentValue(double elapsedTime);
		bool IsCompleted { get;}
		double StartTime { get; set;}
		
	}
}
