using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;

namespace artfulplace.Animia.Storyboard
{
	public class TriStateKeyFrame : IKeyFrame
	{

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value is bool)
				{
					var b = (bool)value;
					if (b)
					{
						_value = MsoTriState.msoTrue;
					}
					else
					{
						_value = MsoTriState.msoFalse;
					}
				}
				else
				{
					_value = MsoTriState.msoFalse;
				}
			}
		}

		private MsoTriState _value { get; set;}

		public double KeyTime { get; set;}
		
	}
}
