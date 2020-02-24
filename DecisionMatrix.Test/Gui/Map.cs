
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

namespace Economy.Gui
{
	 /// <summary>
	 /// represents a console graphic \see this.Display
	 /// </summary>
	 public class Map
	 {
		  /// <summary>
		  /// console horizontal length of map
		  /// </summary>
		  public int Width;

		  /// <summary>
		  /// console vertical length of map
		  /// </summary>
		  public int Height;

		  /// <summary>
		  /// Gets list of objects we draw on the map \see this.Display
		  /// </summary>
		  public List<Sprite> Sprites {get; set;}

		  /// <summary>
		  /// Gets actual map data
		  /// </summary>
		  internal TileType[][] TileTypes {get; set;}

		  /// <summary>
		  /// Initializes a new instance of the <see cref="TileTypes" /> class. with dimensions
		  /// </summary>
		  /// <param name="inWidth">horizontal length to create</param>
		  /// <param name="inHeight">vertical length to create</param>
		  public Map(int inWidth, int inHeight)
		  {
			   this.Width = inWidth;
			   this.Height = inHeight;

			   Sprites = new List<Sprite>();
			   TileTypes = new TileType[this.Width][];
			   for (int x = 0; x < TileTypes.Length; x++)
			   {
					TileTypes[x] = new TileType[this.Height];
			   }
		  }

		  /// <summary>
		  /// draw a representation of \ref this.map on the console
		  /// </summary>
		  /// <param name="yOffset">vertical length to offset drawing by</param>
		  public void Display(int yOffset = 0)
		  {
			   // Draw the map's tiles
			   for (int x = 0; x < TileTypes.Length; x++)
			   {
					int y = 0;
					while (y < TileTypes[x].Length + 0)
					{
						 Console.SetCursorPosition(x, y + yOffset);
						 Console.Write(ToAscii(TileTypes[x][y]));
						 y += 1;
					}
			   }


			   // Draw people on top of the map
			   for (int i = 0; i < Sprites.Count; i++)
			   {
					Console.SetCursorPosition(Sprites[i].X, Sprites[i].Y + yOffset);
					Sprites[i].PrintColor();
			   }

			   Console.SetCursorPosition(0, Height + yOffset);
		  }

		  /// <summary>
		  /// fills \ref this.map with procedural data
		  /// </summary>
		  public void Generate()
		  {
			   DrawBorder();
		  }

		  /// <summary>
		  /// adds to the list of objects we draw
		  /// </summary>
		  /// <param name="inSprite">object to add</param>
		  public void Register(Sprite inSprite)
		  {
			   Sprites.Add(inSprite);
		  }

		  /// <summary>
		  /// single character representation of a specific tile
		  /// </summary>
		  /// <param name="tile">tile to represent</param>
		  /// <returns>single character representation</returns>
		  public string ToAscii(TileType tile)
		  {
			   switch (tile)
			   {
					case (TileType.Border):
						 return "█";
			   }

			   return " ";
		  }

		  /// <summary>
		  /// adds a border of walls around \ref this.map
		  /// </summary>
		  private void DrawBorder()
		  {
			   // Draw horizontal borders
			   DrawLine(0, 0, Width);
			   DrawLine(0, Height - 1, Width);

			   // Draw vertical borders
			   DrawLine(0, 0, Height, true);
			   DrawLine(Width - 1, 0, Height, true);
		  }

		  // TODO Why do it this way?

		  /// <summary>
		  /// adds walls in a horizontal line
		  /// </summary>
		  /// <param name="x">starting horizontal position</param>
		  /// <param name="y">starting vertical position</param>
		  /// <param name="length">horizontal length to draw</param>
		  private void DrawLine(int x, int y, int length)
		  {
			   int i = x;
			   while (i < length + x)
			   {
					TileTypes[i][y] = TileType.Border;
					i += 1;
			   }
		  }

		  // TODO Why do it this way?
		  // HACK: Using extra argument for overloading

		  /// <summary>
		  /// adds walls in a vertical line
		  /// </summary>
		  /// <param name="x">starting horizontal position</param>
		  /// <param name="y">starting vertical position</param>
		  /// <param name="length">vertical length to draw</param>
		  /// <param name="vertical">used to create overload</param>
		  private void DrawLine(int x, int y, int length, bool vertical)
		  {
			   int i = y;
			   while (i < length + y)
			   {
					TileTypes[x][i] = TileType.Border;
					i += 1;
			   }
		  }

	 }
}