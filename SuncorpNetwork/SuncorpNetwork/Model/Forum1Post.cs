﻿using System;
using SQLite;

namespace SuncorpNetwork
{
	public class Forum1Post
	{	
		[PrimaryKeyAttribute, AutoIncrement]
		public int ID { get; set;}
		public string Forum1PostTitle { get; set;}
		public string Forum1PostContent { get; set;}
		public string AuthorName { get; set;}
		public Forum1Post ()
		{
		}
	}
}
