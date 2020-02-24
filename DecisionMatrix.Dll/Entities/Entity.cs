
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace DecisionMatrix.Entities
{

	 /// <summary>
	 /// This class is a noun that represents a particular portion of definite space with defined boundaries.
	 /// </summary>
	 public abstract class Entity : Sprite
	 {
		  public abstract string Name {get; set;}

		  public abstract PlaceType Type {get; set;}

		  public Feature Features {get; set;}

		  public Entity(Vector2 inLocation)
		  {
			   base.X = inLocation.X;
			   base.Y = inLocation.Y;
		  }

	 }
}