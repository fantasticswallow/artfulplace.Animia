using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Office.Interop.PowerPoint;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace artfulplace.Animia.Animations
{
	/// <summary>
	/// アニメーションに対応するタイムライン
	/// </summary>
	public class Timeline : ITimeline
	{
		public Timeline()
		{
			IsFinished = false;
		}
				
		public IAnimation Animation { get; set;}

		public object TargetObject { get; set;}

		public string PropertyName { get; set;}

		public bool IsFinished { get; set;}

		public void timerUpdate(double elapsedSeconds)
		{
			if (Animation.StartTime <= elapsedSeconds)
			{
				// dynamic obj = (TargetObject as Microsoft.Office.Interop.PowerPoint.Shape);
				// var t = TargetObject.GetType();
				// var obj = new ExpandoObject();
				// var res = TargetObject.GetType().InvokeMember(PropertyName, System.Reflection.BindingFlags.SetProperty, null, TargetObject, new object[] { Animation.CurrentValue(elapsedSeconds) });

				var csite = CallSite<Action<CallSite, object, object>>.Create(
								Binder.SetMember(CSharpBinderFlags.None, 
									PropertyName, 
									typeof(Timeline),
									new CSharpArgumentInfo[] {
										CSharpArgumentInfo.Create(
										CSharpArgumentInfoFlags.None, null)}));
				csite.Target.Invoke(csite, TargetObject,Animation.CurrentValue(elapsedSeconds));

				// TargetObject.GetType().GetProperty(this.PropertyName).SetValue(TargetObject, Animation.CurrentValue(elapsedSeconds));
				//var p = obj as IDictionary<string,object>;
				//p[PropertyName] =  Animation.CurrentValue(elapsedSeconds);
				if (Animation.IsCompleted)
				{
					IsFinished = true;
				}
			}
		}

		public void SetDefaultValue()
		{
			var csite = CallSite<Action<CallSite, object, object>>.Create(
								Binder.SetMember(CSharpBinderFlags.None,
									PropertyName,
									typeof(Timeline),
									new CSharpArgumentInfo[] {
										CSharpArgumentInfo.Create(
										CSharpArgumentInfoFlags.None, null)}));
			csite.Target.Invoke(csite, TargetObject, Animation.CurrentValue(0.0));
			IsFinished = false;
		}
	}
}
