
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace DecisionMatrix.Common
{
	 /// <summary>
	 /// represents an object that can be drawn by \ref Map
	 /// </summary>
	 public abstract class Sprite
	 {
		  /// <summary>
		  /// represents left position on map
		  /// </summary>
		  public int X;

		  /// <summary>
		  /// represents top position on map
		  /// </summary>
		  public int Y;

		  /// <summary>
		  /// Gets coordinate on map
		  /// </summary>
		  public Vector2 Position
		  {
			   get
			   {
					return new Vector2(this.X, this.Y);
			   }
		  }

		  /// <summary>
		  /// Color used by PrintColor
		  /// </summary>
//INSTANT C# TODO TASK: Instance fields cannot be initialized using other instance fields in C#:
//ORIGINAL LINE: Public Color As Color = Color.Wheat
		  public Color Color = Color.Wheat;

		  /// <summary>
		  /// prints a colored representation based on \ref ToAscii
		  /// </summary>
		  public void PrintColor()
		  {
			   Console.Write(ToAscii(), Color);
		  }

		  /// <summary>
		  /// single character representation
		  /// </summary>
		  public virtual string ToAscii()
		  {
			   return "■";
		  }

	 }
}