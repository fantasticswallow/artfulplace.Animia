using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using artfulplace.Animia.Events;

namespace artfulplace.Animia
{
	public partial class ThisAddIn
	{
		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{
			Application.AfterPresentationOpen += Application_AfterPresentationOpen;
			Application.SlideShowNextClick += Events.SlideMoveManager.Application_SlideNextClick;
			Application.SlideShowEnd += Application_SlideShowEnd;
			// Application.PresentationSave += Application_PresentationSave;
			Events.SlideMoveManager.TriggerCollection = new List<SlideMoveEventTrigger>();
		}

		//void Application_PresentationSave(PowerPoint.Presentation Pres)
		//{
		//	var sh = ShapeObjectResolver.Resolve(3, 2) as PowerPoint.Shape;
		//	sh.Flip(Office.MsoFlipCmd.msoFlipHorizontal);
		//}

		void Application_SlideShowEnd(PowerPoint.Presentation Pres)
		{
			Events.SlideMoveManager.CurrentPage = 0;
			Events.SlideMoveManager.AnimationIndex = 0;
		}

		void Application_AfterPresentationOpen(PowerPoint.Presentation Pres)
		{	
			Sample.TestCodeInvoker.ReadyAnimation2();
		}

		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
		{
		}

		#region VSTO で生成されたコード

		/// <summary>
		/// デザイナーのサポートに必要なメソッドです。
		/// このメソッドの内容をコード エディターで変更しないでください。
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
		}
		
		#endregion
	}
}
