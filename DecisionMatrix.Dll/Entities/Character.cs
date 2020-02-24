
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using DecisionMatrix.Needs;

namespace DecisionMatrix.Entities
{

	 /// <summary>
	 ///  This class represents a non-player character (NPC).
	 ///  It is a character in a game which that is not controlled by a player. 
	 /// </summary>
	 public abstract class Character : Sprite
	 {
		  protected Physical Physical {get;} = new Physical();

		  protected Esteem Esteem {get;} = new Esteem();

		  protected Safety Safety {get;} = new Safety();

		  protected Growth Growth {get;} = new Growth();

		  protected Social Social {get;} = new Social();

		  /// <summary>
		  /// Unique set identifying title used to refer to a Character
		  /// </summary>
		  /// <returns></returns>
		  public string Name {get; set;}

		  /// <summary>
		  /// What <see cref="PlaceType"/> place type is nearest the character
		  /// </summary>
		  /// <returns></returns>
		  public PlaceType Vicinity {get; set;}

		  /// <summary>
		  /// Sets and determines the leading tendencies for character
		  /// </summary>
		  /// <returns></returns>
		  public FeatureTypes Preference {get; set;} = FeatureTypes.Work;

		  public Character()
		  {
		  }

		  public virtual void Evaluate()
		  {
			   EvaluatePhysical();
			   EvaluateEsteem();
			   EvaluateSafety();
			   EvaluateGrowth();
			   EvaluateSocial();

			   double TotalValues = Physical.Value + Esteem.Value + Safety.Value + Growth.Value + Social.Value;

			   Physical.Weight = Physical.Value / TotalValues;
			   Esteem.Weight = Esteem.Value / TotalValues;
			   Safety.Weight = Safety.Value / TotalValues;
			   Growth.Weight = Growth.Value / TotalValues;
			   Social.Weight = Social.Value / TotalValues;

			   //' Add additional weight proprotionate to preference
			   switch (Preference)
			   {
					case FeatureTypes.Break:
					case FeatureTypes.Home:
					case FeatureTypes.Cook:
					case FeatureTypes.Wander:
						 Physical.Weight += 3;

						 break;
					case FeatureTypes.Dance:
					case FeatureTypes.Drink:
					case FeatureTypes.Eat:
					case FeatureTypes.Visit:
						 Social.Weight += 3;

						 break;
					case FeatureTypes.Deposit:
					case FeatureTypes.Shop:
						 Esteem.Weight += 3;

						 break;
					case FeatureTypes.Learn:
						 Growth.Weight += 3;

						 break;
					case FeatureTypes.Work:
						 Safety.Weight += 3;

						 break;
			   }
		  }

		  public abstract void EvaluatePhysical();

		  public abstract void EvaluateEsteem();

		  public abstract void EvaluateSafety();

		  public abstract void EvaluateGrowth();

		  public abstract void EvaluateSocial();

	 }

}
