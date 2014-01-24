using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Storyboard
{
	/// <summary>
	/// Storyboardにおけるアニメーションのベース
	/// </summary>
	public interface IAnimationBase
	{
		Animations.IAnimation CreateAnimation();
	}
}
