using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
//using SQLite.Net.Attributes;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Home : ContentPage
	{
		//[PrimaryKey]
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;

		public Home ()
		{
			InitializeComponent ();
			createSearchBy ();
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());
			NewsSection.Children.Add (createNewsPost());

			TagsBtn.Clicked += tagBtnOnClick;
		}

		/**	Creates the search by picker with a string[].
		 **/
		public void createSearchBy(){
			foreach (string sort in sortBy){
				SortByPicker.Items.Add(sort);
			}
			SortByPicker.BackgroundColor = Color.Transparent;
			SortByPicker.Title = SortByPicker.Items [0];
			SortByPicker.SelectedIndex = 0;
		}

		/** Initialise the tags array from the database.
		 * 		Also initialises the gotTags Dictionary.
		 *	Post: tags[] - the list of tags to use.
		 **/
		private Tags[] initTags(){
			// Setup tags array
			Tags[] tempTagAr = {
				new Tags{Name = "IT", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Education", TextColour = Color.White, isChecked = false},
				new Tags{Name = "Website", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Construction", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Etc", TextColour = Color.White, isChecked = false}
			};

			return tempTagAr;
		}

		/** Create the tag choices temporary page.
		 **/
		private void createTagChoices(){
			// Initialise tags
			Tags[] tagAr = initTags ();

			// Create the shown elements
			ListView lView = new ListView {
				BackgroundColor = Color.Black
			};
					
			Button done = new Button {
				Text = "Done"
			};

			// Setup those elements
			lView.ItemSelected += noSelection;
			lView.ItemTapped += tappedSelection;
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

			// Create the temporary page
			this.Navigation.PushModalAsync (new ContentPage {
				Content = options
			});
		}

		/**	Mark the selection to checked/unchecked 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event argument - convert e.Item to tags class
		 **/
		private void tappedSelection(object sender, ItemTappedEventArgs e){
			((Tags)e.Item).isChecked = !((Tags)e.Item).isChecked;
			((ListView)sender).ItemTemplate = tagsChoiceListViewData();
		}
		/**	Disable the selection event for the tag selection 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		private void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}

		/** Create a DataTemplate for the tags list view.
		 * 	Post: DataTemplate - the newly created DataTemplate
		 **/
		private DataTemplate tagsChoiceListViewData(){
			DataTemplate template = new DataTemplate (typeof (ImageCell));

			template.SetBinding(ImageCell.TextProperty, "Name");
			template.SetBinding(ImageCell.TextColorProperty, "TextColour");
			template.SetBinding (ImageCell.ImageSourceProperty, "checkImage");

			return template;
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
		private void sendBack(object sender, EventArgs e){
			this.Navigation.PopModalAsync ();
			tagLock = false;
		}

		/** Create a news post grid layout
		 * 	Post: Grid - the news post grid layout
		**/
		public Grid createNewsPost(){
			string infoText = "I have started a business featuring an education based website. Pm me for More info.";
			string footerText = "#Education";

			// Create the grid
			Grid grid = createFeedGridMain ();

			// Create the labels
			Label info = createFeedLabel (infoText, 10);
			Label tagFooter = createFeedLabel (footerText, 8);

			// Create the readmore link
			Button readMore = new Button {
				Text = "Read More...",
				TextColor = Color.FromHex("#007064"),
				FontSize = 10,
				BackgroundColor = Color.Transparent,
				HeightRequest = 25,
				WidthRequest = 50
			};

			// Add children
			grid.Children.Add (createInnerGrid(),0, 2, 0, 1);
			grid.Children.Add (info, 0, 2, 1, 2);
			grid.Children.Add (tagFooter, 0, 1, 2, 3);
			grid.Children.Add (readMore, 1, 2, 2, 3);

			return grid;
		}

		/**	Create the main grid that holds the other grids for the post
		 * 	Post: Grid - the main grid
		 **/
		private Grid createFeedGridMain(){
			// Setup the grid
			Grid grid = new Grid {
				Padding = new Thickness(10,5,10,5), 
				RowSpacing = 1,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White
			};

			RowDefinition r = new RowDefinition ();
			r.Height = 40;
			grid.RowDefinitions.Insert (0, r);

			RowDefinition r1 = new RowDefinition ();
			r1.Height = 60;
			grid.RowDefinitions.Insert (1 , r1);

			RowDefinition r2 = new RowDefinition ();
			r2.Height = 30;
			grid.RowDefinitions.Insert (2 , r2);

			ColumnDefinition c = new ColumnDefinition ();
			c.Width = GridLength.Auto;
			grid.ColumnDefinitions.Add (c);

			return grid;
		}

		/** Creates the inner grid that holds the label grid and profile picture.
		 * 	Post: Grid - the inner grid.
		 **/
		private Grid createInnerGrid(){
			string profileImageLoc = "profile_filler.png";

			// Setup the inner grid that holds profile picture + label grid
			Grid innerGrid = new Grid {
				Padding = 0
			};
			ColumnDefinition c = new ColumnDefinition();
			ColumnDefinition c1 = new ColumnDefinition();
			ColumnDefinition c2 = new ColumnDefinition();

			c.Width = 25;
			innerGrid.ColumnDefinitions.Insert(0, c);

			c1.Width = 50;
			innerGrid.ColumnDefinitions.Insert(1, c1);

			c2.Width = 50;
			innerGrid.ColumnDefinitions.Insert(2, c2);

			// Create the profile image
			Image profileImage = new Image {
				Source = profileImageLoc,
				HeightRequest = 15,
				WidthRequest = 25,
				BackgroundColor = Color.FromHex("#007064")
			};

			innerGrid.Children.Add (profileImage, 0 ,0);
			innerGrid.Children.Add (createLabelGrid(), 1, 10, 0, 1);

			return innerGrid;
		}

		/** Create the label grid that holds the posters name and the date+time of post.
		 * 	Post: Grid - the label grid.
		 **/
		private Grid createLabelGrid(){
			string nameText = "FirstName" + " " + "LastName";
			string dataTimeText = "##:##xx ## MMM YYYY";

			// Setup the label grid that holds the labels name and dateTime
			Grid labelGrid = new Grid {
				Padding = 0
			};

			RowDefinition r = new RowDefinition ();
			r.Height = GridLength.Auto;;
			labelGrid.RowDefinitions.Add(r);
		
			ColumnDefinition c = new ColumnDefinition();
			c.Width = 60;
			labelGrid.ColumnDefinitions.Add (c);

			// Create Labels
			Label name = createFeedLabel (nameText, 12);
			name.FontAttributes = FontAttributes.Bold;
			name.WidthRequest = 500;

			Label dateTime = createFeedLabel (dataTimeText, 8);
			dateTime.FontAttributes = FontAttributes.Italic;

			// Add lables
			labelGrid.Children.Add (name, 0, 8, 0, 1);
			labelGrid.Children.Add (dateTime, 3, 7, 1, 2);

			return labelGrid;
		}

		/** Creates a label for the feed post
		 * 	Pre: 	text - the text to be applied to label
		 * 			fontSize - the size of the font to be applied to label
		 * 	Post: Label - the newly created Lable
		 **/
		private Label createFeedLabel(string text, int fontSize){
			Color textColour = Color.FromHex ("#007064");

			Label l = new Label {
				Text= text,
				TextColor = textColour,
				FontSize = fontSize
			};

			return l;
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

//		public string[] searchTags(){
//		from
//		where
//		orderby
//		select
//			return null;
//		}
	}
}

