
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
using DecisionMatrix.Entities;

namespace Economy.Entities
{

	 /// <summary>
	 /// This class represents a Place <see cref="Entity"/> that exists to satisfy distinctive and unique need(s).
	 /// </summary>
	 public class Goldmine : Entity
	 {
		  public override string Name {get; set;} = "Goldmine";

		  public override PlaceType Type {get; set;} = PlaceType.Goldmine;

		  public Goldmine(Vector2 inLocation) : base(inLocation)
		  {

			   Features = new Feature
			   {
				   Name = Name,
				   Safety = 100,
				   Social = 22,
				   Esteem = 70,
				   Physical = 0,
				   Growth = 30
			   };

		  }

		  /// <summary>
		  /// Display on map
		  /// </summary>
		  /// <returns>single character string representation</returns>
		  public override string ToAscii()
		  {
			   return "G";
		  }

	 }
}