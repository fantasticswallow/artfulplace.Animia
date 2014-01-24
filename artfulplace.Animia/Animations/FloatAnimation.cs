using System;

namespace artfulplace.Animia.Animations
{
	public class FloatAnimation : ArithmeticAnimation
	{
		protected override Type valueType
		{
			get
			{
				return typeof(float);
			}
		}
	}
}
