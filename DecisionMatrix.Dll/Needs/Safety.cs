
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
	 /// This class represents the needs for security and safety. 
	 /// People want control and order in their lives.  Therefore, finding a job, 
	 /// obtaining health insurance and health care, contributing money to a savings account, 
	 /// and moving into a safer neighborhood are all examples of actions motivated by the security and safety need.
	 /// </summary>
	 public sealed class Safety
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
