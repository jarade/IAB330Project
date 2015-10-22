using System;
using SQLite.Net.Attributes;

namespace SuncorpNetwork.Data
{
	public class Tag
	{
		[PrimaryKey]
		public string TagName{ get; set;}

		public Tag (string name)
		{
			TagName = name;
		}
	}
}

