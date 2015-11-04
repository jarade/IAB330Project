using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuncorpNetwork
{
	public class Forum1PostGenerator
	{
		private int post_counter  { get; set; }
		private static List<string> Forum1PostTitle = new List<string> {
			"Title Test 1",
			"Title Test 2"
		};

		private static List<string> Forum1PostContent = new List<string> {
			"Content Test 1",
			"you are noob"
		};

		public static List<Forum1Post> CreatePosts() {
			//fpost 1 = variable hold datas, Forum1Post = get set method, post_f1 = temporary data 
			List<Forum1Post> fpost1 = new List<Forum1Post>();

			for (int i = 0; i < 100; i++) {
				string title   = Forum1PostTitle [i];
				string content_f1 = Forum1PostContent [i];
				Forum1Post post_f1 = new Forum1Post();
				post_f1.Forum1PostTitle = title;
				post_f1.Forum1PostContent = content_f1;
				fpost1.Add (post_f1);

			}
			return fpost1;
		}
	}
}

