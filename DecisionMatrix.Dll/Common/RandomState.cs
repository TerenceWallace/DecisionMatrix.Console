
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace DecisionMatrix.Common
{

	 /// <summary>
	 /// A class representing the state of a pseudo-random number generation algorithm 
	 /// at a point in time. This POCO (Plain Old C# Object) can be easily serialized and deserialized
	 /// </summary>
	 public class RandomState
	 {
		  /// <summary>
		  /// The seed that was originally used to create the pseudo-random number generator
		  /// </summary>
		  /// <remarks>
		  /// Most generators only use 1 seed, but some like the KnownSeriesRandom generator may use multiple seeds
		  /// so that is why Seed is expressed as an array of Doubles here
		  /// </remarks>
		  public double[] Seed {get; set;}

		  /// <summary>
		  /// The number of times that the Next method has been called on the pseudo-random number generator being used
		  /// </summary>
		  public long NumberGenerated {get; set;}

	 }
}
