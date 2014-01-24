using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace artfulplace.Animia.Animations
{
	/// <summary>
	/// 同一のタイミングで実行を行うすべてのTimelineを管理します
	/// </summary>
	public class TimelineCollection
	{
		public TimelineCollection()
		{
			timer.Interval = TimeSpan.FromMilliseconds(10);
			timer.Tick += timer_Tick;
		}

		void timer_Tick(object sender, EventArgs e)
		{
			var dr = (double)sw.ElapsedMilliseconds / 1000;
			foreach (var tl in Timelines.Where(x => !x.IsFinished))
			{
				tl.timerUpdate(dr);
			}
			if (Timelines.All(x => x.IsFinished))
			{
				timer.Stop();
				sw.Stop();
			}
		}

		public void Start()
		{
			timer.Start();
			sw.Start();
		}

		public void SetDefault()
		{
			foreach (var tl in Timelines)
			{
				tl.SetDefaultValue();
			}
		}

		private DispatcherTimer timer = new DispatcherTimer();
		private Stopwatch sw = new Stopwatch();

		public IEnumerable<Timeline> Timelines { get; set;}
	}
}
