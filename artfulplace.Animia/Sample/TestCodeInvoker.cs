using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artfulplace.Animia.Animations;
using artfulplace.Animia.Animations.Behaviors;
using artfulplace.Animia.Events;
using Microsoft.Office.Interop.PowerPoint;

namespace artfulplace.Animia.Sample
{
	internal class TestCodeInvoker
	{
		internal static void ReadyAnimation()
		{
			var widthTimeline = new Timeline();
			var widthAnimation = new FloatAnimation();
			widthAnimation.StartTime = 0.0;
			widthAnimation.IsDecrement = true;
			widthAnimation.FinishTime = 1.0;
			widthAnimation.Expression = x => (32.77 - ((((-1 * x * x) + 1)  * 16.385) * 2)) * 28.35;

			widthTimeline.Animation = widthAnimation;
			widthTimeline.PropertyName = "Width";
			widthTimeline.TargetObject = (Shape)ShapeObjectResolver.Resolve(3, 2);
			
			var leftTimeline = new Timeline();
			var leftAnimation = new FloatAnimation();
			leftAnimation.StartTime = 0.0;
			leftAnimation.FinishTime = 1.0;
			leftAnimation.Expression = x => ((((33.867 / 2) - 0.47) * Math.Sqrt(x)) + 0.47) * 28.35;

			leftTimeline.Animation = leftAnimation;
			leftTimeline.PropertyName = "Left";
			leftTimeline.TargetObject = (Shape)ShapeObjectResolver.Resolve(3, 2);

			var col =new TimelineCollection();
			var lst = new List<Timeline>();
			lst.Add(widthTimeline);
			lst.Add(leftTimeline);
			col.Timelines = lst;

			var trig = new SlideMoveEventTrigger();
			trig.Timeline = col;
			trig.Trigger = new SlideMoveEventTrigger.SlideEventTriggerKey();
			trig.Trigger.Page = 3;
			trig.Trigger.Index = 1;

			SlideMoveManager.TriggerCollection.Add(trig);
		}

		internal static void ReadyAnimation2()
		{
			//var widthTimeline = new Timeline();
			//var widthAnimation = new FloatAnimation();
			//widthAnimation.StartTime = 0.0;
			//widthAnimation.IsDecrement = false;
			//widthAnimation.FinishTime = 2.0;
			//widthAnimation.Expression = x => 1080 * x;

			//widthTimeline.Animation = widthAnimation;
			//widthTimeline.PropertyName = "Rotation";
			//widthTimeline.TargetObject = (Shape)ShapeObjectResolver.Resolve(3, 2);

			var leftTimeline = new BehaviorTimeline();
			var leftAnimation = new ShapeCycleBehavior();
			leftAnimation.StartTime = 0.0;
			leftAnimation.FinishTime = 4.0;
			// leftAnimation.Expression = x => 10.0;

			leftTimeline.Behavior = new IBehavior[] { leftAnimation };
			leftTimeline.TargetObject = (Shape)ShapeObjectResolver.Resolve(3, 2);

			var col = new TimelineCollection();
			var lst = new List<ITimeline>();
			//lst.Add(widthTimeline);
			lst.Add(leftTimeline);
			col.Timelines = lst;

			var trig = new SlideMoveEventTrigger();
			trig.Timeline = col;
			trig.Trigger = new SlideMoveEventTrigger.SlideEventTriggerKey();
			trig.Trigger.Page = 3;
			trig.Trigger.Index = 1;

			SlideMoveManager.TriggerCollection.Add(trig);
		}
	}
}
