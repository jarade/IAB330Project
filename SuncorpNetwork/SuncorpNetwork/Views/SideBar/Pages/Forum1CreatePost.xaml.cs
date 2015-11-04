using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Forum1CreatePost : ContentPage
	{

		public Forum1CreatePost()
		{
			InitializeComponent ();
		}
			

		public async void  OnSubmit (object sender, EventArgs e)
		{
			string postTitle = PostTitle.Text;
			string postContent = PostContent.Text;
			string authorName = ((App)Application.Current).UserEmail;

			if (postTitle != "") {
				if (postContent != "") {
						Forum1Post new_post = new Forum1Post (postTitle,postContent,authorName);
						var database = new Forum1DB ();
						database.InsertNewPost (new_post);
									}
			}
		}
		private void Clear(){
			PostTitle.Text = PostContent.Text = String.Empty;
		}

		private void OnCancel (object o, EventArgs e)
		{
			Clear ();
		}
			
	}
}

