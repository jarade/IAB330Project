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
	public partial class Home : BaseView
	{
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;
		private newsfeedPost post = new newsfeedPost ();
		private TagList tlist = new TagList();
		private int NewsCounter {set; get;}
		private string UserEmail { get{ return UserEmail; } set{ /*Do Nothing*/}}
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://suncorpnetwork.azure-mobile.net/",
			"nWaDxQYaSGAIlEYlJtiiGNWeVkqXST96"
		);

		public Home ()
		{
			DisplayAlert ("Trial", "There is no user logged in.", "Ok");
			StartUp ();
		}
		public Home(string email){
			UserEmail = email;
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

		public void Scrolled(){
<<<<<<< HEAD
			DisplayAlert("H","H","H");
=======
			///DisplayAlert("H","H","H",);
>>>>>>> origin/master
		}
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

			int current = NewsCounter;
			foreach (ProjectDetails item in databaseItems) {
				if (current+4 >= NewsCounter) {
					NewsCounter++;

					Grid g = post.createNewsPost (item);

					NewsSection.Children.Add (g);
				} else {
					break;
				}
			}
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

