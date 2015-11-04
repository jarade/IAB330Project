//using System;
//using System.Collections.Generic;
//
//using Xamarin.Forms;
//
//namespace SuncorpNetwork
//{
//	public partial class Forum1CreatePost : ContentPage
//	{
//
//		public Forum1CreatePost (int id)
//		{
//			InitializeComponent ();
//			var post = App.Database.GetTitle(id);
//			PostTitle.Text = post.Forum1PostTitle;
//			PostContent.Text = post.Forum1PostContent;
//			PostAuthor.Text = post.AuthorName;
//			updateID = id;
//		}
//
//		public Forum1CreatePost()
//		{
//			InitializeComponent ();
//		}
//
//		public void OnSubmit(object o, EventArgs e){
//			Forum1Post forum1 = new Forum1Post();
//			forum1.Forum1PostTitle = PostTitle.Text;
//			forum1.Forum1PostContent = PostContent.Text;
//			forum1.AuthorName = PostAuthor.Text;
//			forum1.ID = updateID; 
//			Clear();
//			App.Database.SavePost(forum1);
//			Navigation.PushAsync (new Forum1 ());
//		}
//
//		private void Clear(){
//			PostTitle.Text = PostContent.Text = PostAuthor.Text = String.Empty;
//		}
//
//		private void OnCancel (object o, EventArgs e)
//		{
//			Clear ();
//		}
//			
//	}
//}
//
