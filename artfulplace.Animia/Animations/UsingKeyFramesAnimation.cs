using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artfulplace.Animia.Storyboard;

namespace artfulplace.Animia.Animations
{
	public class UsingKeyFramesAnimation : IAnimation
	{
		public object CurrentValue(double elapsedTime)
		{
			var fr = KeyFrames.Where(x => x.KeyTime <= elapsedTime).OrderByDescending(x => x.KeyTime).FirstOrDefault();

			return fr.Value;
		}

		public IEnumerable<IKeyFrame> KeyFrames { get; set;}

		private bool _isCompleted = false;

		public bool IsCompleted
		{
			get { return _isCompleted; }
		}

		public double StartTime { get; set;}
		
	}
}
