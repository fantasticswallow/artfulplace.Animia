using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations.Preset
{
	public class FlipAnimation : ArithmeticAnimation
	{
		public FlipAnimation()
		{
			this.Expression = x => FirstValue - (x * x * (FirstValue / 2)) - (Math.Sqrt(x) * (FirstValue / 2));
		}

		public float FirstValue { get; set;}


	}
}
