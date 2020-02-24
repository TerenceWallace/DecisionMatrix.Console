
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

using System.Threading;
using Economy.Entities;
using Console = Colorful.Console;

namespace Economy
{
	 /// <summary>
	 /// represents the main entry point when executed
	 /// </summary>
	 public class Program
	 {

		  private static string[] Population = {"AngryWussoos", "JohnGeese", "StabbyGaming", "Big Hoss", "Ardeos", "E.B.", "human_supremacist", "Quaranuard", "Malscythe", "Quauos", "RobbieW", "SadCloud123", "Sean", "Sense", "Westermin", "wubbalubbadubdub", "vassvik"};

		  /// <summary>
		  /// represents the main entry point when executed
		  /// \see Program.Run
		  /// </summary>
		  /// <param name="args">ignored launch parameters</param>
		  public static void Main(string[] args)
		  {

			   Program mProgram = new Program();

			   int ret = mProgram.Run();

			   // Run() has finished, and returned a code
			   Console.WriteLine("Program has terminated " + ((ret == 0) ? "successfully" : "with exit code " + ret));
			   Console.ReadKey();
		  }

		  /// <summary>
		  /// actual program code, instanced
		  /// calls \ref this.MainLoop
		  /// </summary>
		  /// <returns>0 on success</returns>
		  public int Run()
		  {
			   // Use refelction to show our version number
			   Console.WriteLine("EconomyTest v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

			   MatrixRandom r = new MatrixRandom();

			   // Because Windows CMD is limited to 16 colors, we only use 8 for players.
			   Color[] ourColors = new Color[11]; // Also : Wheat , LawnGreen , Yellow , White , Black
			   for (int i = 0; i < ourColors.Length; i++)
			   {
					ourColors[i] = Color.FromArgb(Convert.ToInt32(r.Next(255)), Convert.ToInt32(r.Next(255)), Convert.ToInt32(r.Next(255)));
			   }

			   Manager.Instance.BuildPlaces();

			   int j = 0;
			   foreach (string name in Population)
			   {
					Agent agent = new Agent(name);

					agent.X = Convert.ToInt32(r.Next(Manager.Instance.Map.Width - 2));
					agent.Y = Convert.ToInt32(r.Next(Manager.Instance.Map.Height - 2));

					// Because Windows CMD is limited to 16 colors, we only use 8 for players.
					agent.Color = ourColors[j];
					j += 1;
					if (j >= ourColors.Length)
					{
						 j = 0;
					}

					Manager.Instance.Map.Register(agent);

					// Everyone gets a basic allowance
					agent.Seed("Money", r.Next(9) + r.Next(6));
					agent.Seed("Bread", r.Next(24) + r.Next(6));
					agent.Seed("Water", r.Next(24) + r.Next(6));

					// DecisionMatrix dependent variables
					agent.Seed("Achievement", r.Next(5) + r.Next(6));
					agent.Seed("Generation", r.Next(5) + r.Next(6));
					agent.Seed("Health", r.Next(5) + r.Next(6));
					agent.Seed("Skill", r.Next(5) + r.Next(6));
					agent.Seed("Education", r.Next(5) + r.Next(6));
					agent.Seed("Perception", r.Next(5) + r.Next(6));
					agent.Seed("Relationship", r.Next(5) + r.Next(6));

					Manager.Instance.Databind(ref agent);
			   }

			   Manager.Instance.Map.Display();

			   Utils.LogInfo("Press any key to simulate...");
			   Console.ReadKey();
			   Console.ReadKey();
			   Console.Clear();

			   // Manager main loop
			   int ret = this.MainLoop();

			   Utils.LogInfo("Manager finished simulating.");
			   Console.ReadKey();
			   return ret;
		  }

		  /// <summary>
		  /// looping portion of program code
		  /// </summary>
		  /// <param name="market">economy instance to simulate</param>
		  /// <param name="map">map to draw agents on</param>
		  /// <returns>0 on success</returns>
		  private int MainLoop()
		  {
			   int retCode = 0;

			   Utils.LogInfo("Manager Simulating ...");
			   int countAlive = Manager.Instance.Agents.Count;

			   // Loop economy until only one person is left.
			   while (countAlive > 1)
			   {
					// Clear old Logs
					Utils.ClearArea(0, Manager.Instance.Map.Height + 2, 10, 63);

					// Displya the map at 0,0
					Console.SetCursorPosition(0, 0);
					Manager.Instance.Map.Display();

					// Show events that happened during the Turn
					Console.SetCursorPosition(0, Manager.Instance.Map.Height + 1);
					countAlive = Manager.Instance.Update();

					// Show table header
					Console.SetCursorPosition(55, Manager.Instance.Map.Height + 1);
					Console.Write("         Player            |   $|Food|Water", Color.Wheat);

					// Show player status per alive Agent
					Utils.ClearArea(63, Manager.Instance.Map.Height + 2, Manager.Instance.Agents.Count, 37);

					for (int i = 0; i < Manager.Instance.Agents.Count; i++)
					{
						 Agent agent = Manager.Instance.Agents[i];
						 if (agent.IsAlive)
						 {

							  var th = new Thread(() => agent.Evaluate(Manager.Instance.Places));
							  th.Start();

							  Console.SetCursorPosition(63, Manager.Instance.Map.Height + 2 + i);
							  Console.Write(Manager.Instance.Agents[i].ToString(), Manager.Instance.Agents[i].Color);
						 }
					}

					// Wait 1.2 seconds per turn .
					Thread.Sleep(1200);
			   }

			   // Everyone is dead, show the final map status
			   Manager.Instance.Map.Display();

			   // Clear everything but the map
			   Utils.ClearArea(0, Manager.Instance.Map.Height, Manager.Instance.Agents.Count + 2, 100);

			   // Show the result screen
			   Console.SetCursorPosition(0, Manager.Instance.Map.Height + 3);

			   var result = from a in Manager.Instance.Agents
				   where a.IsAlive
				   select a;

			   // HACK: Ignore (or really, use) the error where nobody wins.
			   string winner = "Nobody";
			   try
			   {
					winner = result.First().ToString();
					Utils.LogWarn("Manager WE HAVE FOUND A WINNER");
			   }
			   catch
			   {
			   }

			   Utils.LogWarn("Manager Winner: " + winner);
			   Utils.LogWarn($"Manager Lasted {Manager.Instance.Ticks} rounds.");

			   return retCode;
		  }

	 }
}