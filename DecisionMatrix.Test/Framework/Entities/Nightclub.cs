
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
	 /// This class represents a Place <see cref="Entity"/> that exists to satisfy very distinctive and unique need(s).
	 /// </summary>
	 public class Nightclub : Entity
	 {
		  public override string Name {get; set;} = "Nightclub";

		  public override PlaceType Type {get; set;} = PlaceType.Nightclub;

		  public Nightclub(Vector2 inLocation) : base(inLocation)
		  {

			   Features = new Feature
			   {
				   Name = Name,
				   Safety = 0,
				   Social = 100,
				   Esteem = -6,
				   Physical = 0,
				   Growth = -10
			   };

		  }


		  /// <summary>
		  /// Display on map
		  /// </summary>
		  /// <returns>single character string representation</returns>
		  public override string ToAscii()
		  {
			   return "N";
		  }


	 }
}