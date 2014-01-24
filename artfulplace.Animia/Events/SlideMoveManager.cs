using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Events
{
	public class SlideMoveManager
	{
		public SlideMoveManager()
		{
			TriggerCollection = new List<SlideMoveEventTrigger>();
			CurrentPage = 0;
			AnimationIndex = 0;
		}
		
		internal static int CurrentPage { get; set;}

		/// <summary>
		/// 現在のページ内でのアニメーションのインデックスを指定します
		/// </summary>
		internal static int AnimationIndex { get; set;}

		internal static void Application_SlideNextClick(Microsoft.Office.Interop.PowerPoint.SlideShowWindow wn,Microsoft.Office.Interop.PowerPoint.Effect ef)
		{
			if (CurrentPage < wn.View.CurrentShowPosition)
			{
				AnimationIndex = 0;
				CurrentPage = wn.View.CurrentShowPosition;
			}
			else
			{
				AnimationIndex += 1;
			}
			var obj = TriggerCollection.FirstOrDefault(x => x.IsMatchTrigger(CurrentPage,AnimationIndex));
			if (obj != null)
			{
				obj.Timeline.Start();
			}

			var sh = ShapeObjectResolver.Resolve(3, 2) as Microsoft.Office.Interop.PowerPoint.Shape;
			sh.Flip(Microsoft.Office.Core.MsoFlipCmd.msoFlipHorizontal);
		}

		internal static List<SlideMoveEventTrigger> TriggerCollection { get; set;}
	}
}
