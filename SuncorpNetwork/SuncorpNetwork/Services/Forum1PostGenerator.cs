using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public class Forum1PostGenerator
	{
		private static List<string> Forum1PostTitle = new List<string> {
			"Need help with xamarin studio!!",
			"Offically done with the database, too complicated"
		};

		private static List<string> Forum1PostContent = new List<string> {
			"Xamarin forms is so hard to use. Can someone give me sone guides?",
			"Spend few days on fixing database still cant get it to work"
		};

		public static List<Forum1Post> CreatePosts() {
			//fpost 1 = variable hold datas, Forum1Post = get set method, post_f1 = temporary data 
			var postDB = new Forum1DB();

			List<Forum1Post> fpost1 = new List<Forum1Post>();

			for (int i = 0; i < Forum1PostTitle.Count ; i++) {
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

