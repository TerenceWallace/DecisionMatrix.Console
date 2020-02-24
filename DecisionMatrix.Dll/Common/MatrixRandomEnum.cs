
using DecisionMatrix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DecisionMatrix.Common
{
	 /// <summary>
	 /// A class implementing IRandom which used for generating pseudo-random numbers 
	 /// using the System.Random class from the .Net framework
	 /// </summary>
	 public class MatrixRandomEnum<T>
	 {

		  private IList<T> _list = new List<T>();
		  private bool _unique = false;

		  // Fields
		  private System.Random _random;

		  public MatrixRandomEnum(bool IsUnique = false)
		  {
			   _unique = IsUnique;
			   _list = new List<T>((IList<T>)System.Enum.GetValues(typeof(T)));

			   _random = new System.Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), NumberStyles.HexNumber));
		  }

		  public T GetRandom()
		  {
			   if (_unique)
			   {
					if (_list.Count == 0)
					{
						 throw new InvalidOperationException("The list is exhausted. No more unique items could be returned.");
					}
					int index = _random.Next(0, _list.Count);
					T o = _list[index];
					_list.RemoveAt(index);
					return o;
			   }
			   else
			   {
					return _list[_random.Next(0, _list.Count)];
			   }
		  }


	 }
}
