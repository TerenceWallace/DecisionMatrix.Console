using Dapper;
using System.IO;
using System.Linq;
using System.Data.SQLite;

namespace Economy.Models
{
     /// <summary>
     /// 
     /// </summary>
     public class Item : Model
     {
          /// <summary>
          /// Number of items represented
          /// </summary>
          public double Quantity { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="Item" /> class from a database template
          /// </summary>
          /// <param name="itemName">name of ItemTemplate in database</param>
          public Item(string itemName)
          {
               using (SQLiteConnection conn = Connection())
               {
                    conn.Open();

                    var result = conn.Query<Model>("SELECT * FROM Models WHERE Name = @Name", new { Name = itemName }).FirstOrDefault();

                    Name = result.Name;
                    Value = result.Value;
                    Weight = result.Weight;
               }
          }

          /// <summary>
          /// Gets the path to our SQLite database
          /// </summary>
          public static string FilePath
          {
               get
               {
                    return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Models.db");
               }
          }

          /// <summary>
          /// Gets a connection to the SQLite database
          /// </summary>
          /// <returns>unopened connection to database</returns>
          public static SQLiteConnection Connection()
          {
               return new SQLiteConnection("Data Source=" + FilePath);
          }

     }
}