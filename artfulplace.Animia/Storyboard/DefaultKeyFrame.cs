using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Storyboard
{
	public class DefaultKeyFrame : IKeyFrame
	{

		public object Value { get; set; }
		
		public double KeyTime { get; set;}
		
	}
}
