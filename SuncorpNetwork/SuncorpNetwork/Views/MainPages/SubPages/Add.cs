using System;
using System.Collections.Generic;
using SuncorpNetwork.Data.ViewModel;
using SuncorpNetwork.Data;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace SuncorpNetwork
{
	public class Add : TabbedPage
	{
		AddViewModel a = new AddViewModel();

		public Add (){
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
				Orientation = ScrollOrientation.Vertical
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
				Text = "*Title:\t\t\t",
				TextColor = Color.White,
				FontSize = 20
			};

			Entry titleEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				MinimumWidthRequest = 400,
				WidthRequest = 400
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

			StackLayout tagStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness (10)
			};

			Label tagLabel = new Label {
				Text = "*Tags:\t\t\t",
				TextColor = Color.White,
				FontSize = 20
			};

			Button tagBtn = new Button{
				Text = "Select Tags",
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				MinimumWidthRequest = 400,
				WidthRequest = 400
			};

			tagBtn.Clicked += (object sender, EventArgs e) => {
				tagClicked();
			};

			tagStack.Children.Add (tagLabel);
			tagStack.Children.Add (tagBtn);

			StackLayout locationStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10)
			};

			Label locationLabel = new Label {
				Text = "Location:\t",
				TextColor = Color.White,
				FontSize = 20
			};

			Entry locationEntry = new Entry {
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				MinimumWidthRequest = 400,
				WidthRequest = 400
			};

			locationEntry.TextChanged += (object sender, TextChangedEventArgs e) => {
				Location = e.NewTextValue;
			};

			locationStack.Children.Add (locationLabel);
			locationStack.Children.Add (locationEntry);

			StackLayout detailsStack = new StackLayout {
				Orientation = StackOrientation.Vertical
			};

			Label detailLabel = new Label {
				Text = "*Details:\t",
				TextColor = Color.White,
				FontSize = 20
			};

			MyEditor information = new MyEditor {
				WidthRequest = 400,
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
				FontSize = 20
			};

			MyEditor peopleEditor = new MyEditor {
				WidthRequest = 400,
				HeightRequest = 200
			};

			peopleEditor.TextChanged += (object sender, TextChangedEventArgs e) => {
				Expertise = e.NewTextValue;
			};

			peopleStack.Children.Add (peopleLabel);
			peopleStack.Children.Add (peopleEditor);

			bodyStack.Children.Add (tagStack);
			bodyStack.Children.Add (locationStack);
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
				Padding = new Thickness (25, 0, 25, 0),
				BackgroundColor = Color.FromHex ("#007064"),
				OutlineColor = Color.Transparent
			};
			
			StackLayout footer = new StackLayout {
				Padding = new Thickness(25,0,25,0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
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
				Scale = 2,
				BackgroundColor = Color.Transparent,
				Image = source,
				WidthRequest = 50
			};

			return newButton;
		}

		private void saveProject (){
			string first = "Jarrod";
			string last = "Eades";

			if (ProjectTitle != "") {
				if (Details != "") {
					if (Expertise != "") {
						ProjectDetails newProject = new ProjectDetails (first, last, Title, Details, Expertise);
						var database = new ProjectDetailsDatabase ();
						database.InsertOrUpdateProject (newProject);
						insertItem (newProject);
						DisplayAlert ("Created", "The project has been saved", "Ok");
						switchPage (new Home ());
					} else {errorMsg("Expertise Wanted");}
				} else {errorMsg("Details");}
			} else {errorMsg("Title");}
		}

		private void errorMsg (string error){
			DisplayAlert ("Error", "The " + error + " section was not filled in, please fill it in and try again.", "Ok");
		}

		private void tagClicked(){

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

			ScrollView scroll = createScroll ();
			scroll.Content = bodyStack;

			content.Children.Add (scroll, 0, 0);
			content.Children.Add(createFooter (), 0, 1);
			return content;
		}
	}
}

