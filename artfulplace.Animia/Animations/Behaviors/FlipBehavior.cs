using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;

namespace artfulplace.Animia.Animations.Behaviors
{
	public class FlipBehavior : ShapeBehaviorBase
	{
		public override void SetShapeValue(double time, Microsoft.Office.Interop.PowerPoint.Shape sh)
		{
			if (IsHorizontal)
			{
				sh.Flip(MsoFlipCmd.msoFlipHorizontal);
			}
			else
			{
				sh.Flip(MsoFlipCmd.msoFlipVertical);
			}
			isCompleted = true;
		}

		public bool IsHorizontal { get; set;}
	}
}
