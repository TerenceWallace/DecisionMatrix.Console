
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
	 /// This class represents realizing personal potential, self-fulfillment, 
	 /// seeking personal growth and peak experiences. 
	 /// A desire “to become everything one is capable of becoming”
	 /// </summary>
	 public sealed class Growth
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
