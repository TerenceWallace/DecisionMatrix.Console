Short economics game to analyze human behavior and approach to simulate NPC decision making.

Introduction
What motivates human behavior? Maslow's hierarchy of needs is one of the best-known theories of motivation. According to humanist psychologist Abraham Maslow, our actions are motivated in order to achieve certain needs. This is an endeavor to analyze human behavior and simulate decision making.  

This is a game experiment created in order to analyze how well agents are able to converge towards an optimal solution to a problem.  This is a game containing a bunch of subjects, and a bunch of decisions to be made on an individual basis.  The goal of any one subject is to, by the end of the game, possess a favorable (or at least positive) amount of capital.

Overview
This article presents a multiple criteria decision making analysis that contributes to the selection of the most convenient supplier (i.e. Nightclub, Saloon, Bank, Bedroom, Bathroom, etc.) to meet certain needs. The ability of these  potential suppliers to meet an Agent need is evaluated based upon the supplier's individual feature sets.   Rather than taking into account only the cost factor in typical games, here we have appropriately determined our needs and weighted those needs to come up with criteria that aids in the supplier selection process.  Suppliers are identified, the considered weights are assessed, along with the decision maker’s preferences and existing constraints. 

The variants are ranked in terms of their suitability using a DecisionMatrix. The results obtained from this simulation experiment suggest that this methodology is a feasible Non-Playable Character(NPC) decision support model.


Simulation
In this game, there are two groups: the Alive group and Dead group. The Alive group will always receive a constant amount of capital in each round, whereas the Dead group will lose any amount they may have gained (i.e. Loot).  A game has an indefinite number of rounds, or until all the agents are dead. 

At each turn, Agents must consume some kind of Food (Bread counts) and some kind of Water (Liquor counts) to survive.  Agents move around the Map.  Agents Trade with each-other, and Loot other dead Agents.  When only one Agent is left surviving, they are marked as the winner.  

Dead Agents are shown as a '-', where as Alive agents are shown as '+'. Other enties (i.e. suppliers) are denoted by capialized letters ((B)ank, (S)chool, (X)Home, etc.) .


Needs
Needs are categorized accordinging to Maslow's Need Chart.  In this example, we are classifying 5 basic needs as Physical, Esteem, Safety, Growth, and Social. Although there could be more, each need consist of only two factors. 


Evaluate
For each Update an Agent will Evaluate and assign weights based on it's current status.  This allows the agent to define it's decision matrix.  The decision matrix is a classification algorithm.  This helps the agent to figure out which supplier to choose.  The agent must evaluate and calculate it's needs and preference.  Preference allows us to randomize Agent outcomes to an even greater degree.

Decision
Once the Agent has Evaluated its needs it must then make a decision.  The decision process starts with a specified set of alternatives assessed on pseudo-criteria and aggregates the preferential data into a fuzzy
outranking relation. Once started, a distinct number of suppliers are created.  The supplier selection criteria and alternatives are predefined.  For every criterion, the direction of preference has to be specified. The value of the preference should be set in descending. For example the if an agent's hunger increases, then the preference to satisfy that need should increase and its preference to fall in comparison.

Summary
Maslow's hierarchy of needs is a motivational theory in psychology comprising a five-tier model of human needs, often depicted as hierarchical levels within a pyramid. This experiment has attempted to encapsulate the basic principles of Maslow's theory into a game whereby NPC models can Evaluate and determine how best to meet their own unique needs.


REF:
https://github.com/AlbinoGeek
https://github.com/TerenceWallace/DecisionMatrix

