
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
	 /// This class represents the third level of human needs.
	 /// Social involves feelings of belongingness. 
	 /// The need for interpersonal relationships that motivates behavior
	 /// </summary>
	 public sealed class Social
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
