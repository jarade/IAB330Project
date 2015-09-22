using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Home : ContentPage
	{
		private Dictionary<string, bool> gotTags = new Dictionary<string, bool>();
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;

		public Home ()
		{
			InitializeComponent ();
			createSearchBy ();
			createNewsPost ();
			TagsBtn.Clicked += tagBtnOnClick;
		}
			
		public void createSearchBy(){
			foreach (string sort in sortBy)
			{
				SortByPicker.Items.Add(sort);
			}
			SortByPicker.BackgroundColor = Color.Black;
			SortByPicker.Title = SortByPicker.Items [0];
		}

		private string[] initTags(){
			// Get tags from database...
			string[] tags = {"IT", "Education", "Website", "Construction", "Etc"};
			foreach (string tag in tags) {
				if (!gotTags.ContainsKey (tag)) {
					gotTags.Add (tag, false);
				}
			}

			return tags;
		}

		private void createTagChoices(){
			string[] tags = initTags ();

			ListView lView = new ListView {
				RowHeight = 40
			};

			Button done = new Button {
				Text = "Done"
			};

			lView.ItemSelected += noSelection;
			lView.ItemTapped += tappedSelection;
			done.Clicked += sendBack;
			lView.ItemsSource = tags; 
			lView.Parent = NewsSection;

			StackLayout options = new StackLayout {
				Spacing = 10,
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Start,
				Children = {lView, done}
			};

			this.Navigation.PushModalAsync (new ContentPage {
				Content = options
			});
		}

		private void sendBack(object sender, EventArgs e){
			this.Navigation.PopModalAsync ();
			tagLock = false;
		}

		private void tappedSelection(object sender, ItemTappedEventArgs e){
			// Do stuff.
			//DisplayAlert("Tapped", e.Item.ToString(), "Done");
			//gotTags.Add(e.Item.ToString(), !gotTags.TryGetValue(e.Item.ToString()));
		}

		/**	Disable the selection event for the tag selection 
		 **/
		private void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}

		private void tagBtnOnClick(object sender, EventArgs e){
			if(!tagLock){
				tagLock = true;
				createTagChoices ();
			}
		}
			
		public void createNewsPost(){
			// These will be from the database...
			// string mssage = "This message will be displayed as a message. It will be replaced by the database text.";
			//string name = "Jarrod Eades";
			//Image image;
		}
	}
}

