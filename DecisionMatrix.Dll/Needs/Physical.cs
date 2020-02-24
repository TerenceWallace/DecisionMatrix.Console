
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace DecisionMatrix.Needs
{

	 /// <summary>
	 /// These are biological requirements for human survival, e.g. air, food, drink, shelter, clothing, warmth, sex, sleep.
	 /// Maslow considered physiological needs the most important.
	 /// As all the other needs become secondary until these needs are met.
	 /// </summary>
	 public sealed class Physical
	 {
		  public double Value {get; set;}

		  private double _Weight;
		  public double Weight
		  {
			   get
			   {
					return _Weight;
			   }
			   internal set
			   {
					_Weight = value;
			   }
		  }
	 }

}
