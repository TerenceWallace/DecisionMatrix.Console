
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

namespace Economy.Common
{
	 /// <summary>
	 /// various ways an Agent could have died
	 /// </summary>
	 public enum DeathCause
	 {
		  /// <summary>
		  /// not currently dead
		  /// </summary>
		  None,

		  /// <summary>
		  /// death by \ref Food less than 0
		  /// </summary>
		  Starvation,

		  /// <summary>
		  /// death by \ref Water less than 0
		  /// </summary>
		  Dehydration,

		  /// <summary>
		  /// death by unknown cause
		  /// </summary>
		  Unknown
	 }

	 /// <summary>
	 /// temporary enum defining tiles in a \ref Map
	 /// </summary>
	 public enum TileType
	 {
		  None,
		  Border,
		  Water
	 }


}