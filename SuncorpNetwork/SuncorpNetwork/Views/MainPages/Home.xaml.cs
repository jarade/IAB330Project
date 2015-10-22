using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SuncorpNetwork.Data;
using SuncorpNetwork.Data.ViewModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace SuncorpNetwork
{
	public partial class Home : ContentPage
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
			InitializeComponent ();
			createSearchBy ();
			NewsCounter = 0;

			//setupBottomNavigation ();

			setupDatabaseFeed ();
			TagsBtn.Clicked += tagBtnOnClick;
		}

//		private void setupBottomNavigation(){
//			TapGestureRecognizer t = new TapGestureRecognizer ();
//			t.Tapped +=   (object sender, EventArgs e) => {
//				Page page = new Messages();
//				switchPage(page);
//			};
//
//			msgBtn.GestureRecognizers.Add (t);
//		}
//
		private void insertDummyRow(ProjectDetailsDatabase database){
			string[] s = {"IT"};
			if(s != null){
				ProjectDetails p = new ProjectDetails ("Jarrod", "Eades");
				p.Information = "Some basic information.";
				database.InsertOrUpdateProject (p);
			}
		}

		public void setupDatabaseFeed(){
			var database = new ProjectDetailsDatabase ();
			var databaseItems = database.GetItems ().OrderByDescending( x => x.TimeStamp);
			//var rows = getItems ();
			//// Add an extra posts to the feed if possible.
			foreach (ProjectDetails item in databaseItems) {
				NewsCounter++;
				NewsSection.Children.Add (post.createNewsPost (item));
			}
		}

		private async Task<List<ProjectDetails>> getItems(){
			return await MobileService.GetTable<ProjectDetails> ().OrderBy (x => x.TimeStamp).ToListAsync ();
		}
		/** Create the tag choices temporary page.
		 **/
		public void createTagChoices(){
			// Initialise tags
			Tags[] tagAr = tlist.initTags ();

			// Create the shown elements
			ListView lView = new ListView {
				BackgroundColor = Color.Black
			};

			Button done = new Button {
				Text = "Done"
			};

			// Setup those elements
			lView.ItemSelected += tlist.noSelection;
			lView.ItemTapped += tlist.tappedSelection;
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
		public async void sendBack(object sender, EventArgs e){
			await Navigation.PopModalAsync ();
			tagLock = false;
		}

		/** Navigate to a new page
		 * 	stack: the layout view to use
		 **/
		public async void navigateToTemporaryPage(StackLayout stack){
			// Create the temporary page
			await Navigation.PushModalAsync (new BaseView {
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

