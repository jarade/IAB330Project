using System;
using SQLite;
using SQLite.Net.Attributes;

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

		public Forum1Post ( string postTitle, string postContent, string authorName)
		{			 
			Forum1PostTitle = postTitle;
			Forum1PostContent = postContent;
			AuthorName = authorName;
		}
	}
}

