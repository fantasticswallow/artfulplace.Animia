using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;

namespace artfulplace.Animia.Animations.Behaviors
{
	public abstract class ShapeBehaviorBase : BehaviorBase
	{
		public override void SetValue(double time, object sh)
		{
			var s = sh as Shape;
			if (s != null)
			{
				SetShapeValue(time, s);
			}
		}

		public abstract void SetShapeValue(double time, Shape sh);
	}
}
