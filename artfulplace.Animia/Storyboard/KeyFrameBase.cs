using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Animia.Storyboard
{
	/// <summary>
	/// Storyboardの各フレームのベース
	/// </summary>
	public interface IKeyFrame
	{
		object Value { get; set;}

		double KeyTime { get; set;}


	}
}
