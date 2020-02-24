
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
	 public class Saloon : Entity
	 {
		  public override string Name {get; set;} = "Saloon";

		  public override PlaceType Type {get; set;} = PlaceType.Saloon;

		  public Saloon(Vector2 inLocation) : base(inLocation)
		  {

			   Features = new Feature
			   {
				   Name = Name,
				   Safety = 0,
				   Social = 80,
				   Esteem = -36,
				   Physical = 24,
				   Growth = -10
			   };

		  }


		  /// <summary>
		  /// Display on map
		  /// </summary>
		  /// <returns>single character string representation</returns>
		  public override string ToAscii()
		  {
			   return "S";
		  }


	 }
}