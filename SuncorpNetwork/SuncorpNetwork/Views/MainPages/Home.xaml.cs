using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SuncorpNetwork.Data;
using SuncorpNetwork.Data.ViewModel;

namespace SuncorpNetwork
{
	public partial class Home : ContentPage
	{
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;
		private HomeViewModel viewModel = new HomeViewModel();
		private int NewsCounter {set; get;}

		public Home ()
		{
			InitializeComponent ();
			createSearchBy ();
			setupDatabaseFeed ();
			NewsCounter = 0;
			TagsBtn.Clicked += tagBtnOnClick;
		}

		public void setupDatabaseFeed(){
			var database = new ProjectDetailsDatabase ();
			var databaseItems = database.GetItems ();

			// Add an extra 5 posts to the feed if possible.
			foreach (ProjectDetails item in databaseItems) {
				NewsCounter++;
				NewsSection.Children.Add (viewModel.createNewsPost (item));
			}
			DisplayAlert ("Number Of Posts", NewsCounter.ToString (), "Done");
//			for (int i = NewsCounter; i < NewsCounter + 5; i++) {
//				var item = databaseItems.ElementAt(NewsCounter);
//				if (item != null) {
//					string[] tags = item.convertStringToTagArray ();
//					ProjectDetails proj = new ProjectDetails (item.FirstName, item.LastName, tags);
//					proj.addInfo (item.Information);
//				
//					NewsCounter++;
//					NewsSection.Children.Add (viewModel.createNewsPost (proj));
//				}
//			}

		}

		/** Create the tag choices temporary page.
		 **/
		public void createTagChoices(){
			// Initialise tags
			Tags[] tagAr = viewModel.initTags ();

			// Create the shown elements
			ListView lView = new ListView {
				BackgroundColor = Color.Black
			};

			Button done = new Button {
				Text = "Done"
			};

			// Setup those elements
			lView.ItemSelected += viewModel.noSelection;
			lView.ItemTapped += viewModel.tappedSelection;
			done.Clicked += sendBack;

			DataTemplate template = new DataTemplate (typeof (ImageCell));
			template.SetBinding(ImageCell.TextProperty, "Name");
			template.SetBinding(ImageCell.TextColorProperty, "TextColour");
			template.SetBinding (ImageCell.ImageSourceProperty, "checkImage");

			lView.ItemsSource = tagAr;
			lView.ItemTemplate = template;

			// Create the layout to show those elements
			StackLayout options = new StackLayout {
				Spacing = 10,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Children = {lView, done}
			};

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
		public void sendBack(object sender, EventArgs e){
			Navigation.PopModalAsync ();
			tagLock = false;
		}

		/** Navigate to a new page
		 * 	stack: the layout view to use
		 **/
		public void navigateToTemporaryPage(StackLayout stack){
			// Create the temporary page
			Navigation.PushModalAsync (new BaseView {
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

