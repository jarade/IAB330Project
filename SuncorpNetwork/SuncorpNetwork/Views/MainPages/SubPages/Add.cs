using System;
using System.Collections.Generic;
using SuncorpNetwork.Data.ViewModel;
using SuncorpNetwork.Data;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SuncorpNetwork
{
	public class Add : TabbedPage
	{
		AddViewModel a = new AddViewModel();

		public Add (){
			//var database = new ProjectDetailsDatabase ();
			//database.DeleteAllItems ();
			startup ();
		}

		public void startup(){
			this.Title = "Add";
			this.BackgroundColor = Color.FromHex ("#0DA195");

			this.Children.Add (new BaseView {
				Title = "Project",
				BackgroundColor = Color.FromHex("#0DA195"),
				Content = setupProjectPage ()
			});

			this.Children.Add(new BaseView{
				Title = "Business",
				BackgroundColor = Color.FromHex("#0DA195"),
				Content = setupBusinessPage()
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
			//switchPage(new Add ());
		}

		public void profileBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new PersonalProfile ());
		}

		private void switchPage(Page page){
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(page);
		}

		private string ProjectTitle { get; set; }
		private string Location{ get; set; }
		private string Details { get; set; }
		private string Expertise { get; set; }
		private string Email { get; set; }

		private Grid createContentGrid(){
			Grid content = new Grid ();

			RowDefinition r = new RowDefinition ();
			r.Height = new GridLength (9, GridUnitType.Star);
			content.RowDefinitions.Insert (0, r);

			r = new RowDefinition ();
			r.Height =  new GridLength (1.2, GridUnitType.Star);
			content.RowDefinitions.Insert (1, r);

			return content;
		}

		private ScrollView createScroll(){
			ScrollView scroll = new ScrollView{
				Padding = new Thickness(5,5,5,5),
				Orientation = ScrollOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			return scroll;
		}

		private StackLayout createBodyStack(){
			StackLayout bodyStack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Padding = new Thickness(5)
			};

			StackLayout titleStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label titleLabel = new Label {
				Text = "*Title:\t\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Entry titleEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 250
			};

			titleEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				ProjectTitle = e.NewTextValue;
			};

			titleStack.Children.Add (titleLabel);
			titleStack.Children.Add (titleEntry);

			bodyStack.Children.Add (titleStack);

			return bodyStack;
		}

		private Grid setupProjectPage(){
			Grid content = createContentGrid ();
			StackLayout bodyStack = createBodyStack ();

			StackLayout locationStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label locationLabel = new Label {
				Text = "Location:",
				TextColor = Color.White,
				FontSize = 16
			};

			Entry locationEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 250
			};

			locationEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				Location = e.NewTextValue;
			};

			locationStack.Children.Add (locationLabel);
			locationStack.Children.Add (locationEntry);

			StackLayout tagStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness (10)
			};

			Label tagLabel = new Label {
				Text = "*Tags:\t\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Button tagBtn = new Button{
				Text = "Select Tags",
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				WidthRequest = 250,
				HeightRequest = 40
			};

			tagBtn.Clicked += tagClicked;

			tagStack.Children.Add (tagLabel);
			tagStack.Children.Add (tagBtn);

			StackLayout detailsStack = new StackLayout {
				Orientation = StackOrientation.Vertical
			};

			Label detailLabel = new Label {
				Text = "*Details:\t",
				TextColor = Color.White,
				FontSize = 16
			};

			MyEditor information = new MyEditor {
				WidthRequest = 300,
				HeightRequest = 200
			};

			information.TextChanged += (object sender, TextChangedEventArgs e) => {
				Details = e.NewTextValue;
			};

			detailsStack.Children.Add (detailLabel);
			detailsStack.Children.Add (information);

			StackLayout peopleStack = new StackLayout {
				Orientation = StackOrientation.Vertical
			};

			Label peopleLabel = new Label {
				Text = "*Expertise Wanted:\t",
				TextColor = Color.White,
				FontSize = 16
			};

			MyEditor peopleEditor = new MyEditor {
				WidthRequest = 300,
				HeightRequest = 200
			};

			peopleEditor.TextChanged += (object sender, TextChangedEventArgs e) => {
				Expertise = e.NewTextValue;
			};

			peopleStack.Children.Add (peopleLabel);
			peopleStack.Children.Add (peopleEditor);

			bodyStack.Children.Add (locationStack);
			bodyStack.Children.Add (tagStack);
			bodyStack.Children.Add (detailsStack);
			bodyStack.Children.Add(peopleStack);

			StackLayout submitStack = new StackLayout {
				Padding = new Thickness (20),
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.EndAndExpand
			};

			Button submitProject = new Button {
				Text = "Submit Project",
				TextColor = Color.Black,
				BackgroundColor = Color.White
			};

			submitProject.Clicked += (object sender, EventArgs e) => {
				saveProject();
			};

			submitStack.Children.Add (submitProject);
			bodyStack.Children.Add (submitStack);

			ScrollView scroll = createScroll ();
			scroll.Content = bodyStack;

			content.Children.Add (scroll, 0, 0);
			content.Children.Add (createFooter (), 0, 1);
			return content;
		}
		
		private Frame createFooter(){
			Frame frame = new Frame {
				Padding = new Thickness (15, 0, 15, 0),
				BackgroundColor = Color.FromHex ("#007064"),
				OutlineColor = Color.Transparent,
				HeightRequest = 50
			};
			
			StackLayout footer = new StackLayout {
				Padding = new Thickness(0,0,0,0),
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			Button message = createButton ("ic_chat_white_24dp.png");
			message.Clicked += messageBtnClicked;

			Button alert = createButton ("ic_notifications_white_24dp.png");
			alert.Clicked += alertBtnClicked;

			Button home = createButton ("ic_account_balance_white_24dp.png");
			home.Clicked += homeBtnClicked;

			Button add = createButton ("ic_add_circle_white_24dp.png");
			//add.Clicked += addBtnClicked;

			Button profile = createButton ("ic_account_circle_white_24dp.png");
			profile.Clicked += profileBtnClicked;

			footer.Children.Add (message);
			footer.Children.Add (alert);
			footer.Children.Add (home);
			footer.Children.Add (add);
			footer.Children.Add (profile);

			frame.Content = footer;

			return frame;
		}

		private Button createButton(string source){
			Button newButton = new Button {
				Scale = 1.5,
				BackgroundColor = Color.Transparent,
				Image = source,
				WidthRequest = 50
			};

			return newButton;
		}

		private void saveProject (){

			if (ProjectTitle != "") {
				if (Details != "") {
					if (Expertise != "") {
						string tags = "";
						// Add tags as string
						foreach (string tagName in tlist.tagChecked.Keys) {
							bool isChecked;
							tlist.tagChecked.TryGetValue (tagName, out isChecked);
							if(isChecked){
								if (tags != "") {
									tags += "|" + tagName;
								} else {
									tags = tagName;
								}
							}
						}
						// Get personal information 
						var personalInfo = new PersonalDB ();
						PersonalDetails pd = personalInfo.GetDetails (((App)Application.Current).UserEmail);

						// Create the project table
						ProjectDetails newProject = new ProjectDetails (pd.FirstName, pd.LastName, Title, Details, Expertise, tags, ((App)Application.Current).UserEmail);
						var database = new ProjectDetailsDatabase ();
						database.InsertOrUpdateProject (newProject);
						//insertItem (newProject);

						DisplayAlert ("Created", "The project has been created", "Ok");
						switchPage (new Home ());
					} else {errorMsg("Expertise Wanted");}
				} else {errorMsg("Details");}
			} else {errorMsg("Title");}
		}

		private void errorMsg (string error){
			DisplayAlert ("Error", "The " + error + " section was not filled in, please fill it in and try again.", "Ok");
		}

		private TagList tlist = new TagList();
		private bool tagLock = false;

		private string newTagName;

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

			Entry newTag = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				Placeholder = "Add the tag here..."
			};
			newTag.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
				newTagName = ((Entry)sender).Text;
			};

			Button addNew = new Button {
				Text = "Add New Tag",
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
			addNew.Clicked += addNewClicked;

			options.Children.Add (newTag);
			options.Children.Add (addNew);

			navigateToTemporaryPage (options);
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

		private async void addNewClicked(object sender, EventArgs e){
			// Check to see if there is a tag
			if(newTagName != ""){
				// Check if user error/accident
				var response = await DisplayAlert("Confirmation", "Do you wish to add " + newTagName 
														+ ". Warning, doing this will uncheck all tags selected so far.", 
													"No, take me back", "Yes, add it");
				// No = true and yes is false hence !response
				if (!response) {
					if (!tlist.tagChecked.ContainsKey (newTagName)) {
						// Add new tag to database
						var database = new TagDatabase ();
						Tag t = new Tag (newTagName);
						database.InsertOrUpdateTag (t);
						tlist.addToDictionary (t.TagName);

						// Reload list
						await Navigation.PopModalAsync ();
						createTagChoices ();
					} else {
						await DisplayAlert ("Error:", "The tag name is already in the list, please check the entry field and try again.", "Back");
					}
				} 
			}else {
				await DisplayAlert ("Error:", "The tag name was not specified, please check the entry field and try again.", "Back");
			}
		}

		/**	Tag button click event
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		private void tagClicked(object sender, EventArgs e){
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

		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://suncorpnetwork.azure-mobile.net/",
			"nWaDxQYaSGAIlEYlJtiiGNWeVkqXST96"
		);

		private async void insertItem(ProjectDetails item){
			//CurrentPlatform.Init();
			try{
				await MobileService.GetTable<ProjectDetails>().InsertAsync(item);

			}catch (Exception e){
				DisplayAlert ("ERROR", e.ToString(), "Done");
			}
		}

		private Grid setupBusinessPage(){
			Grid content = createContentGrid ();
			StackLayout bodyStack = createBodyStack ();

			StackLayout sloganStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label sloganLabel = new Label {
				Text = "Slogan:\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Entry sloganEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 250
			};

			sloganStack.Children.Add (sloganLabel);
			sloganStack.Children.Add (sloganEntry);

			StackLayout imageStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label imageLabel = new Label {
				Text = "Logo:\t\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Button imageSelector = new Button {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 280,
				HeightRequest = 40,
				Text = "Select Image"
			};
			imageStack.Children.Add (imageLabel);
			imageStack.Children.Add (imageSelector);

			StackLayout locationStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label locationLabel = new Label {
				Text = "Address:\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Entry locationEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 250
			};
			locationStack.Children.Add (locationLabel);
			locationStack.Children.Add (locationEntry);

			StackLayout emailStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label emailLabel = new Label {
				Text = "Email:\t\t",
				TextColor = Color.White,
				FontSize = 16
			};

			Entry emailEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				WidthRequest = 280
			};

			emailEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				Email = e.NewTextValue;
			};

			emailStack.Children.Add (emailLabel);
			emailStack.Children.Add (emailEntry);

			Button submit = new Button {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				Text = "Submit"
			};

			submit.Clicked += businessSubmit;

			bodyStack.Children.Add (sloganStack);
			bodyStack.Children.Add (imageStack);
			bodyStack.Children.Add (locationStack);
			bodyStack.Children.Add (emailStack);
			bodyStack.Children.Add (submit);
			ScrollView scroll = createScroll ();
			scroll.Content = bodyStack;

			content.Children.Add (scroll, 0, 0);
			content.Children.Add(createFooter (), 0, 1);
			return content;
		}

		public async void businessSubmit(Object sender, EventArgs e){
			await DisplayAlert ("Complete", "Congratulations on forming a business", "Done");
			switchPage (new Home ());
		}
	}
}