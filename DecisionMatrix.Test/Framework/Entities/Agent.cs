
using DecisionMatrix.Common;
using DecisionMatrix.Entities;
using Economy.Common;
using Economy.Framework;
using Economy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Console = Colorful.Console;


namespace Economy.Entities
{


     /// <summary>
     /// Represents an entity which takes part in a Manager simulation
     /// </summary>
     public class Agent : Character
     {
          /// <summary>
          /// number of trades this turn
          /// </summary>
          private int trades = 0;

          /// <summary>
          /// amount of food energy we have
          /// </summary>
          private float calories = 100;

          /// <summary>
          /// whether we are still a functioning agent
          /// </summary>
          public bool IsAlive { get; set; } = true;

          /// <summary>
          /// represents our current target coordinate
          /// </summary>
          public Vector2 Destination;

          /// <summary>
          /// if ! \ref this.Alive then this is how we died
          /// </summary>
          public DeathCause CauseOfDeath = DeathCause.None;

          /// <summary>
          /// represents everything the Agent owns
          /// </summary>
          private List<Item> Assets = new List<Item>();

          private Queue<Vector2> DestinationList = new Queue<Vector2>();

          /// <summary>
          /// Initializes a new instance of the <see cref="Agent" /> class. with a name and no items
          /// </summary>
          /// <param name="inName">friendly name, shown in leaderboard</param>
          public Agent(string inName)
          {
               Name = inName;

               // Set a baseline Feature preference for agent
               MatrixRandomEnum<FeatureTypes> pref = new MatrixRandomEnum<FeatureTypes>();
               base.Preference = pref.GetRandom();
          }

          #region Physical
          /// <summary>
          /// Gets the total sum of all edible foods carried
          /// </summary>
          public int Food
          {
               get
               {
                    return ItemCount("Bread");
               }

               private set
               {
                    Seed("Bread", value - ItemCount("Bread"));
               }
          }

          /// <summary>
          /// Gets the total sum of all potable liquids carried
          /// </summary>
          public int Water
          {
               get
               {
                    return ItemCount("Water");
               }

               private set
               {
                    Seed("Water", value - ItemCount("Water"));
               }
          }
          #endregion

          #region Esteem
          /// <summary>
          /// Gets the total sum of all Achievements
          /// </summary>
          public int Achievements
          {
               get
               {
                    return ItemCount("Achievement");
               }

               private set
               {
                    Seed("Achievement", value - ItemCount("Achievement"));
               }
          }

          /// <summary>
          /// Gets the total sum of all currencies carried
          /// </summary>
          public int Wealth
          {
               get
               {
                    return ItemCount("Money");
               }

               private set
               {
                    Seed("Money", value - ItemCount("Money"));
               }
          }

          #endregion

          #region Safety
          /// <summary>
          /// Gets the total sum of all Generations
          /// </summary>
          public int Generations
          {
               get
               {
                    return ItemCount("Generation");
               }

               private set
               {
                    Seed("Generation", value - ItemCount("Generation"));
               }
          }

          /// <summary>
          /// Gets the total sum of all Health
          /// </summary>
          public int Health
          {
               get
               {
                    return ItemCount("Health");
               }

               private set
               {
                    Seed("Health", value - ItemCount("Health"));
               }
          }
          #endregion

          #region Growth
          /// <summary>
          /// Gets the total sum of all Skills
          /// </summary>
          public int Skills
          {
               get
               {
                    return ItemCount("Skill");
               }

               private set
               {
                    Seed("Skill", value - ItemCount("Skill"));
               }
          }

          /// <summary>
          /// Gets the total sum of all Education
          /// </summary>
          public int Education
          {
               get
               {
                    return ItemCount("Education");
               }

               private set
               {
                    Seed("Education", value - ItemCount("Education"));
               }
          }
          #endregion

          #region Social
          /// <summary>
          /// Gets the total sum of all Perceptions
          /// </summary>
          public int Perceptions
          {
               get
               {
                    return ItemCount("Perception");
               }

               private set
               {
                    Seed("Perception", value - ItemCount("Perception"));
               }
          }

          /// <summary>
          /// Gets the total sum of all Relationships
          /// </summary>
          public int Relationships
          {
               get
               {
                    return ItemCount("Relationship");
               }

               private set
               {
                    Seed("Relationship", value - ItemCount("Relationship"));
               }
          }
          #endregion

          /// <summary>
          /// present an item (miraculous creation)
          /// </summary>
          /// <param name="itemName">name of item to create</param>
          /// <param name="quantity">amount to add</param>
          public void Seed(string itemName, double quantity)
          {
               // If we already have on, increase stack count
               var item = Assets.Find((n) => n.Name == itemName);

               if (item != null)
               {
                    for (int i = 0; i < Assets.Count; i++)
                    {
                         if (Assets[i].Name == itemName)
                         {
                              Assets[i].Quantity += quantity;
                         }
                    }
               }
               else
               {
                    // Else create a new stack
                    Item mItem = new Item(itemName);
                    mItem.Quantity = quantity;
                    Assets.Add(mItem);
               }

          }

          /// <summary>
          /// initialize our status
          /// </summary>
          public void Start()
          {
               // Have no destination at the start
               Destination = this.Position;
          }

          /// <summary>
          /// called by \ref Manager to move us forward a cycle
          /// </summary>
          public void Update()
          {
               if (IsAlive)
               {
                    Generations += 1;

                    // If we have reached our destination
                    if (Vector2.Distance(this.Position, Destination) < 2.0F)
                    {
                         if (DestinationList.Count > 0)
                         {
                              var result = (
                                   from v in Manager.Instance.Places
                                   where Vector2.Distance(this.Position, new Vector2(v.X, v.Y)) < 2.0F
                                   select v ).FirstOrDefault();
                              if (result != null)
                              {
                                   // Transfer benefits to the agent
                                   TransferBenefits(result.Features);
                              }

                              // Set a new destination
                              Destination = (Vector2)DestinationList.Dequeue();
                         }
                         else
                         {
                              Destination = Manager.Instance.Map.GetRandomLocation();
                         }

                    }

                    var nearby = this.GetNeighbors(5);
                    Search(nearby.ToList());

                    // Using Linq : Filter our list down to Agents only
                    var agents = nearby.OfType<Agent>();

                    var AgentsAlive = agents.Where((agent) => agent.IsAlive);
                    Trade(AgentsAlive);

                    var dead = agents.Where((agent) => !agent.IsAlive);
                    Loot(dead);

                    // Move towards destination
                    if (Destination.X > X)
                    {
                         X += 1;
                    }
                    else if (Destination.Y > Y)
                    {
                         Y += 1;
                    }
                    else if (Destination.X < X)
                    {
                         X -= 1;
                    }
                    else if (Destination.Y < Y)
                    {
                         Y -= 1;
                    }

                    // Consume resources every 48 ticks
                    if (Manager.Instance.Ticks % Constants.CYCLE_FREQUENCY == 0)
                    {
                         calories -= 11;

                         if (calories < 10 && Food > 0)
                         {
                              Seed("Bread", -1);
                              calories += 50;
                         }

                         Seed("Water", -1);
                    }
               }

               bool newlyDead = false;
               if (( Food <= 0 || Water <= 0 ) && IsAlive)
               {
                    newlyDead = true;
               }

               IsAlive = !( Food <= 0 || Water <= 0 );
               if (Food <= 0)
               {
                    CauseOfDeath = DeathCause.Starvation;
               }

               if (Water <= 0)
               {
                    CauseOfDeath = DeathCause.Dehydration;
               }

               if (newlyDead)
               {
                    Console.WriteLine($" {Name,-18} has died of " + CauseOfDeath.ToString(), System.Drawing.Color.Yellow);
               }
          }

          /// <summary>
          /// Calculates needs influenced by what the Agent values
          /// </summary>
          /// <param name="item"></param>
          public void Evaluate(List<Entity> lst)
          {
               base.Evaluate();

               lock (lst)
               {
                    if (DestinationList.Count <= 0)
                    {

                         foreach (var item in lst)
                         {
                              // Calculate needs influenced by what the Character values
                              string Name = item.Name;

                              double PhysicalValue = item.Features.Physical;
                              double EsteemValue = item.Features.Esteem;
                              double SafetyValue = item.Features.Safety;
                              double GrowthValue = item.Features.Growth;
                              double SocialValue = item.Features.Social;

                              item.Features.Value = ( PhysicalValue * Physical.Weight ) + ( EsteemValue * Esteem.Weight ) + ( SafetyValue * Safety.Weight ) + ( GrowthValue * Growth.Weight ) + ( SocialValue * Social.Weight );
                         }

                         // Sort values
                         Manager.Instance.Logger.Debug($"=========[{Name}]===========");
                         IOrderedEnumerable<Entity> DecisionList = from p in lst
                                                                   orderby p.Features.Value descending
                                                                   select p;

                         foreach (Entity ordereditem in DecisionList)
                         {
                              DestinationList.Enqueue(new Vector2(ordereditem.X, ordereditem.Y));

                              Manager.Instance.Logger.Debug(ordereditem.Name);

                         }
                    }
               }
          }

          /// <summary>
          /// based on \ref Alive status
          /// </summary>
          /// <returns>single character string representation</returns>
          public override string ToAscii()
          {
               return ( IsAlive ? "+" : "-" );
          }

          /// <summary>
          /// basic status information that represents the Agent
          /// </summary>
          /// <returns>string representation</returns>
          public override string ToString()
          {
               return $" {Name,-18}| {Wealth,3}| {Food,3}| {Water,3}";
          }

          /// <summary>
          /// Action: searches the bodies of passed agents nearby and takes their collection
          /// </summary>
          /// <param name="deadAgents">dead agents</param>
          private void Loot(IEnumerable<Agent> deadAgents)
          {
               for (int i = 0; i < deadAgents.Count(); i++)
               {
                    Agent other = deadAgents.ElementAt(i);

                    if (other.Wealth == 0 && other.Food == 0 && other.Water == 0)
                    {
                         Console.WriteLine($" {Name,-18} found the looted body of {other.Name}!", System.Drawing.Color.Wheat);
                         continue;
                    }

                    Wealth += other.Wealth;
                    Food += other.Food;
                    Water += other.Water;


                    other.Wealth -= other.Wealth;
                    other.Food -= other.Food;
                    other.Water -= other.Water;
                    other.Relationships -= other.Relationships;

                    Console.WriteLine($" {Name,-18} looted everything from {other.Name}!", System.Drawing.Color.Wheat);
               }
          }

          // TODO: WHY IS SEARCH NOT A THING?
          private void Search(List<Sprite> nearby)
          {
          }

          /// <summary>
          /// action: given certain trade rules, attempt to take items for money
          /// </summary>
          /// <param name="nearbyAgents">alive agents</param>
          private void Trade(IEnumerable<Agent> nearbyAgents)
          {
               trades = 0;
               for (int i = 0; i < nearbyAgents.Count(); i++)
               {
                    Perceptions += 1;

                    // Do no trades if we are broke
                    if (Wealth <= 0)
                    {
                         return;
                    }

                    Agent other = nearbyAgents.ElementAt(i);

                    if (Food < 5 && other.Food > 10) // Buy Food from others if we need it
                    {
                         // Buy 1 food for 2 Money
                         other.Food -= 1;
                         Wealth -= 2;

                         other.Wealth += 2;
                         Food += 1;

                         // Build a relationship
                         other.Relationships += 1;
                         Relationships += 1;

                         Console.WriteLine($" {Name,-18} bought Food  from {other.Name}!", System.Drawing.Color.LawnGreen);
                    }
                    else if (Water < 5 && other.Water > 10) // Buy Water from others if we need it
                    {
                         // Buy 1 Water for 2 Money
                         other.Water -= 1;
                         Wealth -= 2;

                         other.Wealth += 2;
                         Water += 1;

                         // Build a relationship
                         other.Relationships += 1;
                         Relationships += 1;

                         Console.WriteLine($" {Name,-18} bought Water from {other.Name}!", System.Drawing.Color.LawnGreen);
                    }
                    else
                    {
                         break;
                    }

                    trades += 1;

                    // Limit of 4 trades per turn
                    if (trades == 4)
                    {
                         break;
                    }
               }
          }

          /// <summary>
          /// counts the number of item in this.collection
          /// </summary>
          /// <param name="itemName">name of item to search for</param>
          /// <returns>total count</returns>
          private int ItemCount(string itemName)
          {
               return (int) Assets.Where((item) => item.Name == itemName).Sum((item) => item.Quantity);
          }

          /// <summary>
          /// Transfer benefits to the agent
          /// <see cref="Entity"/>Entity benefits are equally divided based on the number or sub categories available per agent
          /// </summary>
          /// <param name="feature"></param>
          private void TransferBenefits(Feature feature)
          {
               Manager.Instance.Logger.Debug($"========= +[Enter TransferBenefits]+ =========");
               this.Food += Convert.ToInt32(feature.Physical / 2);
               this.Water += Convert.ToInt32(feature.Physical / 2);
               this.Achievements += Convert.ToInt32(feature.Esteem / 2);
               this.Wealth += Convert.ToInt32(feature.Esteem / 2);
               this.Generations += Convert.ToInt32(feature.Safety / 2);
               this.Health += Convert.ToInt32(feature.Safety / 2);
               this.Skills += Convert.ToInt32(feature.Growth / 2);
               this.Education += Convert.ToInt32(feature.Growth / 2);
               this.Perceptions += Convert.ToInt32(feature.Social / 2);
               this.Relationships += Convert.ToInt32(feature.Social / 2);

               Manager.Instance.Logger.Debug($"Transferred: {feature.Name} benefit(s) to {Name}.");
               Manager.Instance.Logger.Debug(this.ToString());

          }

          #region Overrides -[Evaluate] 
          public override void EvaluatePhysical()
          {
               double FoodValue = (double)( ( Food >= 10 ) ? 10 : Food );
               double WaterValue = (double)( ( Water >= 10 ) ? 10 : Water );

               Physical.Value = ( FoodValue + WaterValue ) / 2;
          }

          public override void EvaluateEsteem()
          {
               double AchievementValue = (double)( ( Achievements >= 10 ) ? 10 : Achievements );
               double WealthValue = (double)( ( Wealth >= 10 ) ? 10 : Wealth );

               Esteem.Value = ( AchievementValue + WealthValue ) / 2;
          }

          public override void EvaluateSafety()
          {
               double GenerationValue = (double)( ( Generations >= 10 ) ? 10 : Generations );
               double HealthValue = (double)( ( Health >= 10 ) ? 10 : Health );

               Safety.Value = ( GenerationValue + HealthValue ) / 2;
          }

          public override void EvaluateGrowth()
          {
               double SkillValue = (double)( ( Skills >= 10 ) ? 10 : Skills );
               double EducationValue = (double)( ( Education >= 10 ) ? 10 : Education );

               Growth.Value = ( SkillValue + EducationValue ) / 2;
          }

          public override void EvaluateSocial()
          {
               double PerceptionValue = (double)( ( Perceptions >= 10 ) ? 10 : Perceptions );
               double RelationshipValue = (double)( ( Relationships >= 10 ) ? 10 : Relationships );

               Social.Value = ( PerceptionValue + RelationshipValue ) / 2;
          }
          #endregion

     }
}
