using System;
using SQLite.Net.Attributes;

namespace SuncorpNetwork.Data
{
	public class Tag
	{
		[PrimaryKey]
		public string TagName{ get; set;}

		// This is required, else it causes crash when trying to access from database. 
		public Tag(){
		}

		public Tag (string name)
		{
			TagName = name;
		}
	}
}

