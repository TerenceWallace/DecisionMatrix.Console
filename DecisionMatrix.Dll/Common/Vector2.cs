
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace DecisionMatrix.Common
{
	 /// <summary>
	 /// represents a coordinate on the map
	 /// </summary>
	 public struct Vector2
	 {

		  public static float Distance(Vector2 v1, Vector2 v2)
		  {
			   return (float)Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
		  }

		  public int X {get; set;}

		  public int Y {get; set;}

		  public Vector2(int inX, int inY) : this()
		  {
			   this.X = inX;
			   this.Y = inY;
		  }
	 }
}