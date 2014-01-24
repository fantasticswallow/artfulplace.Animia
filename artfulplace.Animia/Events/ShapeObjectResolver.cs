using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;

namespace artfulplace.Animia.Events
{
	internal class ShapeObjectResolver
	{
		internal static object Resolve(int page,int shapeId)
		{
			return Globals.ThisAddIn.Application.ActivePresentation.Slides[page].Shapes.Cast<Shape>().FirstOrDefault(x => x.Id == shapeId);
		}
	}
}
