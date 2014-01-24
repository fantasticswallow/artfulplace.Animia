using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Animations
{
	public class IntAnimation : ArithmeticAnimation
	{
		protected override Type valueType
		{
			get
			{
				return typeof(int);
			}
		}
	}
}
