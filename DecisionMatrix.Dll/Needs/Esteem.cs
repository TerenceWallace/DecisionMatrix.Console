
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
	 /// The class represents what Maslow classified into two categories: 
	 /// (i) esteem for oneself (dignity, achievement, mastery, independence) 
	 /// and (ii) the desire for reputation or respect from others (e.g., status, prestige). 
	 /// </summary>
	 public sealed class Esteem
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
