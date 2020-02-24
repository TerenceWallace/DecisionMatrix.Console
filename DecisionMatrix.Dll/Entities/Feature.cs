
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
	/// A Feature represents distinctive attributes or aspects of a <see cref="Entity"/> Place.
	/// </summary>
	public class Feature
	{

		public string Name {get; set;} = "BaseFeature";
		public double Physical {get; set;} = 0.2;
		public double Esteem {get; set;} = 0.2;
		public double Safety {get; set;} = 0.2;
		public double Growth {get; set;} = 0.2;
		public double Social {get; set;} = 0.2;

		public FeatureTypes Type = FeatureTypes.None;

		public double Value {get; set;} = 1;
	}
}