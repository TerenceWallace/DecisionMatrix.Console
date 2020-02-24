
using DecisionMatrix.Common;
using Economy.Common;
using Economy.Framework;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Data;
using System.Drawing;
using System;
using Console = Colorful.Console;

namespace Economy.Common
{
	 /// <summary>
	 /// collection of static helper methods using \ref Colorful.Console
	 /// </summary>
	 public class Utils
	 {
		  /// <summary>
		  /// shows a message on the console of level DEBUG in \ref System.Drawing.Color.SteelBlue
		  /// </summary>
		  /// <param name="message">string to display</param>
		  public static void LogDebug(string message)
		  {
			   Console.WriteLine($"[DEBUG] {message}", System.Drawing.Color.SteelBlue);
		  }

		  /// <summary>
		  /// shows a message on the console of level INFO in \ref System.Drawing.Color.Wheat
		  /// </summary>
		  /// <param name="message">string to display</param>
		  public static void LogInfo(string message)
		  {
			   Console.WriteLine($" [INFO] {message}", System.Drawing.Color.Wheat);
		  }

		  /// <summary>
		  /// shows a message on the console of level WARN in \ref System.Drawing.Color.Yellow
		  /// </summary>
		  /// <param name="message">string to display</param>
		  public static void LogWarn(string message)
		  {
			   Console.WriteLine($" [WARN] {message}", System.Drawing.Color.Yellow);
		  }

		  /// <summary>
		  /// writes blank spaces to an area, thus clearing existing content
		  /// </summary>
		  /// <param name="x">coordinate from left of screen</param>
		  /// <param name="y">coordinate from top of screen</param>
		  /// <param name="h">horizontal length component</param>
		  /// <param name="w">vertical length component</param>
		  public static void ClearArea(int x, int y, int h, int w)
		  {
			   string space = " ";
			   int j = y;
			   while (j < y + h)
			   {
					// Attempting to clear something below the screen
					if (j >= Console.BufferHeight)
					{
						 return;
					}

					Console.SetCursorPosition(x, j);
					int i = x;
					while (i < x + w)
					{
						 Console.Write(space);
						 i += 1;
					}
					j += 1;
			   }
		  }

	 }
}