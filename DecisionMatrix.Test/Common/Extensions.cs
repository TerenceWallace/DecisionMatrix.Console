using DecisionMatrix.Common;
using Economy.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Economy.Common
{
     /// <summary>
     /// A class that defines a
     /// </summary>
     internal static class Extensions
     {


          /// <summary>
          /// gets a list of all MapObjects near us
          /// </summary>
          /// <param name="distance">maximum radius to search</param>
          /// <returns>list of nearby objects</returns>
          public static IEnumerable<Sprite> GetNeighbors(this Sprite spr, float distance)
          {
               // Using Linq : Filter Sprite by Distance < 3
               return
                    from obj in Manager.Instance.Map.Sprites
                    where Vector2.Distance(obj.Position, spr.Position) < distance
                    select obj;
          }

          public static Vector2 GetRandomLocation(this Gui.Map map)
          {
               int RandomX = Convert.ToInt32(Manager.Instance.Random.Next(map.Width - 2));
               int RandomY = Convert.ToInt32(Manager.Instance.Random.Next(map.Height - 2));

               return new Vector2(RandomX, RandomY);
          }

     }

}
