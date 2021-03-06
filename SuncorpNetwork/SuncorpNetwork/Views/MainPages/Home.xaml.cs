﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SuncorpNetwork.Data;
using SuncorpNetwork.Data.ViewModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace SuncorpNetwork
{
	public partial class Home : BaseView
	{
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;
		private newsfeedPost post = new newsfeedPost ();
		private TagList tlist = new TagList();
		private int NewsCounter {set; get;}

		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://suncorpnetwork.azure-mobile.net/",
			"nWaDxQYaSGAIlEYlJtiiGNWeVkqXST96"
		);

		public Home ()
		{
			var database = new ProjectDetailsDatabase ();
			//((App)Application.Current).UserEmail - use this for email thats logged in
			//DisplayAlert ("Trial", "The user logged in is:" + ,  "Ok");
			StartUp ();
		}

		private void StartUp(){
			InitializeComponent ();
			createSearchBy ();
			NewsCounter = 0;

			//setupBottomNavigation ();

			setupDatabaseFeed ();

			TagsBtn.Clicked += tagBtnOnClick;
		}

		public List<ProjectDetails> sortByTags(){
			var database = new ProjectDetailsDatabase ();
			List<string> tags = new List<string> ();

			foreach (string tagName in tlist.tagChecked.Keys) {
				bool isChecked;
				tlist.tagChecked.TryGetValue (tagName, out isChecked);
				if(isChecked){
					tags.Add (tagName);
				}
			}

			// If tags are selected then get items that contain at least one tag else get all items
			if (tags.Count > 0) {
				return database.GetItemsWithTags (tags).OrderByDescending (x => x.TimeStamp).ToList();;
			} else {
				return database.GetItems ().OrderByDescending (x => x.TimeStamp).ToList();
			}
		}

		public void setupDatabaseFeed(){
			var database = new ProjectDetailsDatabase ();
			var databaseItems = sortByTags ();
		
			int current = NewsCounter;
			// TODO add more posts on scroll down, havent figured out how to do the scrolled event thing yet.
			foreach (ProjectDetails item in databaseItems) {
				if (current+9 >= NewsCounter) {
					NewsCounter++;

					Grid g = post.createNewsPost (item);
					g.Children.Add (readMoreButton(item.id), 1, 2, 2, 3);

					NewsSection.Children.Add (g);
				} else {
					break;
				}
			}
		}

		private Button readMoreButton(int id){
			// Create the readmore link
			Button readMore = new Button {
				Text = "Read More...",
				TextColor = Color.FromHex("#007064"),
				FontSize = 12,
				BackgroundColor = Color.Transparent,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};

			readMore.Clicked += (sender, e) => {
				switchPage(new Project(id));
			};

			return readMore;
		}
		private async Task<List<ProjectDetails>> getItems(){
			return await MobileService.GetTable<ProjectDetails> ().OrderBy (x => x.TimeStamp).ToListAsync ();
		}

		/** Create the tag choices temporary page.
		 **/
		public void createTagChoices(){
			Button done = new Button {
				Text = "Done",
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
			done.Clicked += sendBack;

			StackLayout options = tlist.createTagListStack (done);
			navigateToTemporaryPage (options);
		}


		/**	Creates the search by picker with a string[].
		 **/
		public void createSearchBy(){
			foreach (string sort in sortBy){
				SortByPicker.Items.Add(sort);
			}
			SortByPicker.BackgroundColor = Color.Transparent;
			SortByPicker.SelectedIndex = 0;
		}

		/**	Tag button click event
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		private void tagBtnOnClick(object sender, EventArgs e){
			if(!tagLock){
				tagLock = true;
				createTagChoices ();
			}
		}

		/**	Return to the main screen
		 **/
		public async void sendBack(object sender, EventArgs e){
			await Navigation.PopModalAsync ();
			tagLock = false;

			// Reset News Feed
			foreach(View v in NewsSection.Children.ToList()){
				NewsSection.Children.RemoveAt (0);
			}

			setupDatabaseFeed ();
		}

		/** Navigate to a new page
		 * 	stack: the layout view to use
		 **/
		public async void navigateToTemporaryPage(StackLayout stack){
			// Create the temporary page
			await Navigation.PushModalAsync (new BaseView {
				Padding = new Thickness(15,5,15,5),
				BackgroundColor = Color.FromHex("#0DA195"),
				Content = stack
			});
		}

		public void messageBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Messages ());
		}

		public void alertBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Alert ());
		}

		public void homeBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Home ());
		}

		public void addBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Add ());
		}

		public void profileBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new PersonalProfile ());
		}

		private void switchPage(Page page){
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(page);
		}
	}
}

