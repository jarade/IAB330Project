using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace SuncorpNetwork
{
	public partial class Forum1 : ContentPage
	{

		public List<Forum1Post> Fpost1 { get; set; }
		public Forum1 ()
		{
			Init ();
			InitializeComponent();
		}

		private async Task Init(){
			Fpost1 = new List<Forum1Post> ();
			//local variable
			var listOfPosts = new List<Forum1Post>();
			listOfPosts = await Forum1PostGenerator.CreatePosts ();
			Fpost1 = listOfPosts;
			BindingContext = this;

		}

		public void OnItemTapped(object o, ItemTappedEventArgs e){
			var local_fpost = e.Item as Forum1Post;
			if (e != null) {
				DisplayAlert("Aha!",String.Format("The content is {0}",
					local_fpost.Forum1PostContent),"OK");
			}
		}
	}
}

