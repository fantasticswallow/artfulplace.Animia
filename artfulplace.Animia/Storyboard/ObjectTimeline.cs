using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Storyboard
{
	public class ObjectTimeline
	{
		public IAnimationBase[] Animations { get; set;}

		public int Page { get; set; }

		public int ShapeId { get; set; }

		public string TargetProperty { get; set; }
	}
}
