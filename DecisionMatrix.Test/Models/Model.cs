
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

namespace Economy.Models
{
	 /// <summary>
	 /// represents the structure of data in our SQLite Table "ItemTemplates"
	 /// </summary>
	 /// 
	 public class Model
	 {
		  public int ModelID {get; set;}
		  public string Name {get; set;}
		  public float Weight {get; set;}
		  public float Value {get; set;}
	 }

}