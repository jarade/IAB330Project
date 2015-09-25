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
		private Dictionary<string, int> gotTags = new Dictionary<string, int>();
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;
		Tags[] tagAr;

		public Home ()
		{
			InitializeComponent ();
			createSearchBy ();
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

			// Setup lookup dictionary for tags
			int index = 0;
			foreach (Tags tag in tempTagAr) {
				if (!gotTags.ContainsKey (tag.Name)) {
					gotTags.Add (tag.Name, index);
					index++;
				}
			}

			return tempTagAr;
		}

		/** Create the tag choices temporary page.
		 **/
		private void createTagChoices(){
			// Initialise tags
			tagAr = initTags ();

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
			int thisTag; // ((Tags)e.Item).Name == gives string id name
			gotTags.TryGetValue(((Tags)e.Item).Name.ToString(), out thisTag);
			tagAr [thisTag].isChecked = !tagAr [thisTag].isChecked;
			((ListView)sender).ItemTemplate = tagsChoiceListViewData();
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

		/**	Disable the selection event for the tag selection 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		private void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
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
				WidthRequest = 25
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
				BackgroundColor = Color.White
			};

			RowDefinition r = new RowDefinition ();
			r.Height = 40;
			grid.RowDefinitions.Add (r);

			r.Height = 50;
			grid.RowDefinitions.Add (r);

			r.Height = 30;
			grid.RowDefinitions.Add (r);

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
			c.Width = 25;
			innerGrid.ColumnDefinitions.Add(c);

			c.Width = GridLength.Auto;
			innerGrid.ColumnDefinitions.Add(c);

			// Create the profile image
			Image profileImage = new Image {
				Source = profileImageLoc,
				HeightRequest = 25,
				WidthRequest = 25,
				BackgroundColor = Color.FromHex("#007064")
			};

			innerGrid.Children.Add (profileImage, 0 ,0);
			innerGrid.Children.Add (createLabelGrid(), 1, 3, 0, 1);

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
			r.Height = 10;
			labelGrid.RowDefinitions.Add(r);
			r.Height = 13;
			labelGrid.RowDefinitions.Add(r);

			// Create Labels
			Label name = createFeedLabel (nameText, 12);
			name.FontAttributes = FontAttributes.Bold;

			Label dateTime = createFeedLabel (dataTimeText, 10);
			dateTime.FontAttributes = FontAttributes.Italic;

			// Add lables
			labelGrid.Children.Add (name, 0, 2, 0, 1);
			labelGrid.Children.Add (dateTime, 1, 2, 1, 2);

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
			this.Navigation.PushModalAsync (new Messages());
		}

		public void alertBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			this.Navigation.PushModalAsync (new Alert());
		}

		public void homeBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			this.Navigation.PushModalAsync (new Home());
		}

		public void addBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			this.Navigation.PushModalAsync (new Add());
		}

		public void profileBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			this.Navigation.PushModalAsync (new PersonalProfile());
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

