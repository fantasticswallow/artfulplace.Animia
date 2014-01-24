using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Events
{
	public class SlideMoveEventTrigger : IEventTrigger
	{
		public class SlideEventTriggerKey
		{
			public int Page { get; set;}

			public int Index { get; set;}
		}

		public bool IsMatchTrigger(int page,int index)
		{
			return Trigger.Page == page && Trigger.Index == index;
		}

		public SlideEventTriggerKey Trigger { get; set;}

		public Animations.TimelineCollection Timeline { get; set;}


		public void Invoke()
		{
			
		}
	}
}
