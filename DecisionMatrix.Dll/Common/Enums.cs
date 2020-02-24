
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

	public enum PlaceType: int
	{
		None = -1,
		Home = 0,
		Goldmine = 1,
		Bank = 2,
		Saloon = 3,
		School = 5,
		Market = 6,
		Food = 7,
		Nightclub = 8
	}

	public enum FeatureTypes: int
	{
		None,
		Sleep,
		Eat,
		Work,
		Drink,
		Deposit,
		Cook,
		Break,
		Home,
		Learn,
		Shop,
		Visit,
		Dance,
		Wander
	}

}