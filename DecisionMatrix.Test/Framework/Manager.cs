
using DecisionMatrix.Common;
using DecisionMatrix.Entities;
using Economy.Common;
using Economy.Entities;
using Economy.Gui;
using System.Collections.Generic;

namespace Economy.Framework
{

     /// <summary>
     /// Represents a simulated economy, must contain <see cref="Agent"/> Agents
     /// </summary>
     public sealed class Manager
     {

          private static Manager _Instance;

          /// <summary>
          /// Gets reference to our random library, constant to keep seed
          /// </summary>
          public MatrixRandom Random { get; set; }

          /// <summary>
          /// Gets the current round
          /// </summary>
          public long Ticks { get; private set; } = 0;

          public Logger Logger { get; } = new Logger();

          /// <summary>
          /// Gets or sets the world marketplace that objects operate within
          /// </summary>
          internal Map Map { get; set; }

          /// <summary>
          /// Gets list we call <see cref="Agent"/> Agent.Tick on each, every <see cref="Update()"/> this.Tick
          /// </summary>
          internal List<Agent> Agents { get; set; }

          internal List<Entity> Places { get; set; } = new List<Entity>();

          internal static Manager Instance
          {
               get
               {
                    if (null == _Instance)
                    {
                         _Instance = new Manager();
                    }
                    return _Instance;
               }
          }

          private Manager()
          {
               InitializeClass();

          }

          private void InitializeClass()
          {
               this.Random = new MatrixRandom();
               this.Agents = new List<Agent>();

               this.Map = new Map(100, 25);
               this.Map.Generate();
          }


          /// <summary>
          /// register an Agent for inclusion in the simulation
          /// </summary>
          /// <param name="inAgent">Agent to register</param>
          public void Databind(ref Agent inAgent)
          {
               inAgent.Start();
               Agents.Add(inAgent);
          }

          public void BuildPlaces()
          {
               this.Places = new List<Entity>();

               Places.Add(new Bank(this.Map.GetRandomLocation()));
               Places.Add(new Food(this.Map.GetRandomLocation()));
               Places.Add(new Goldmine(this.Map.GetRandomLocation()));
               Places.Add(new Home(this.Map.GetRandomLocation()));
               Places.Add(new Market(this.Map.GetRandomLocation()));
               Places.Add(new Nightclub(this.Map.GetRandomLocation()));
               Places.Add(new Saloon(this.Map.GetRandomLocation()));
               Places.Add(new School(this.Map.GetRandomLocation()));


               foreach (Entity item in Places)
               {
                    Sprite tempVar = item;
                    this.Map.Register(tempVar);
               }
          }

          /// <summary>
          /// \see Agent.Seed
          /// </summary>
          /// <param name="agent">agent to gift</param>
          /// <param name="itemName">name of item to create</param>
          /// <param name="quantity">amount to add</param>
          public void Seed(int agent, string itemName, int quantity)
          {
               Agents[agent - 1].Seed(itemName, quantity);
          }

          /// <summary>
          /// represents a single round of simulation
          /// </summary>
          /// <returns>0 on success</returns>
          public int Update()
          {
               Ticks += 1;

               Utils.LogInfo("Manager [Turn " + Ticks + "]");
               int countAlive = 0;

               for (int i = 0; i < Agents.Count; i++)
               {
                    Agents[i].Update();

                    if (Agents[i].IsAlive)
                    {

                         countAlive += 1;
                    }
               }

               return countAlive;
          }
     }
}
