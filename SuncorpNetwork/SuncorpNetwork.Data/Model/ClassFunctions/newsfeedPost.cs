/*** 
 *	File: newsfeedPost.cs - A file which holds functions to create a newsfeed post.
 *	Author: Jarrod Eades N8855722
 *	Created On: 21/10/2015
 *	Updated: 21/10/2015
 ***/
using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class newsfeedPost
	{

		/** Create a news post grid layout
		 * 	Post: Grid - the news post grid layout
		**/
		public Grid createNewsPost(ProjectDetails project){
			string infoText = project.Information;
			string footerText = project.HasTags;

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

			readMore.Clicked += (sender, e) => {
				navigateTo(0);
			};
				
			// Add children
			grid.Children.Add (createInnerGrid(project.FirstName + " " + project.LastName, project.TimeStamp),0, 2, 0, 1);
			grid.Children.Add (info, 0, 2, 1, 2);
			grid.Children.Add (tagFooter, 0, 1, 2, 3);
			grid.Children.Add (readMore, 1, 2, 2, 3);

			return grid;
		}

		/**	Create the main grid that holds the other grids for the post
		 * 	Post: Grid - the main grid
		 **/
		public Grid createFeedGridMain(){
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
			c.Width = 400;
			grid.ColumnDefinitions.Add (c);

			return grid;
		}

		/** Creates the inner grid that holds the label grid and profile picture.
		 * 	Post: Grid - the inner grid.
		 **/
		public Grid createInnerGrid(string name, DateTime date){
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
			innerGrid.Children.Add (createLabelGrid(name, date), 1, 10, 0, 1);

			return innerGrid;
		}

		/** Create the label grid that holds the posters name and the date+time of post.
		 * 	Post: Grid - the label grid.
		 **/
		public Grid createLabelGrid(string user, DateTime date){
			string nameText = user;
			string dataTimeText = date.Date.ToString();

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
			dateTime.HorizontalOptions = LayoutOptions.EndAndExpand;
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
		public Label createFeedLabel(string text, int fontSize){
			Color textColour = Color.FromHex ("#007064");

			Label l = new Label {
				Text= text,
				TextColor = textColour,
				FontSize = fontSize
			};

			return l;
		}

		/**	Navigate to the page associated with the id
		 * 	Pre: int id - the id of the post.
		 **/
		private void navigateTo(int id){
			// Database connection

			// Get row with id in ProjectDetailsDB.

			// Open the profile of that page.
		}
	}
}

