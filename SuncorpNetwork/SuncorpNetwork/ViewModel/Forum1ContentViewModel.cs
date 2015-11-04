using System;
using System.Collections.Generic;

namespace SuncorpNetwork
{
	public class Forum1ContentViewModel
	{
		public List<Forum1Post> Fpost1 { get; set; }

		public Forum1ContentViewModel ()
		{
			Fpost1 = new List<Forum1Post> ();
			//local variable
			var listOfPosts = new List<Forum1Post>();
			listOfPosts = Forum1PostGenerator.CreatePosts ();
			Fpost1 = listOfPosts;
		}
	}
}

