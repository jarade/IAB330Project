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
			grid.Padding = new Thickness (10);
		
			// Create the labels
			Label info = createFeedLabel (infoText, 14);
			Label tagFooter = createFeedLabel (footerText, 12);
			tagFooter.VerticalOptions = LayoutOptions.EndAndExpand;

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
				navigateTo(project.PosterEmail);
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
				RowSpacing = 10,
				HeightRequest = 200,
				WidthRequest = 500,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White, 
			};

			RowDefinition r = new RowDefinition ();
			r.Height = new GridLength(1.25, GridUnitType.Star);
			grid.RowDefinitions.Insert (0, r);

			RowDefinition r1 = new RowDefinition ();
			r1.Height = new GridLength(1.5, GridUnitType.Star);
			grid.RowDefinitions.Insert (1 , r1);

			RowDefinition r2 = new RowDefinition ();
			r2.Height = new GridLength(0.75, GridUnitType.Star);
			grid.RowDefinitions.Insert (2 , r2);

			ColumnDefinition c = new ColumnDefinition ();
			c.Width = GridLength.Auto;
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
				Padding = 0,
				ColumnSpacing = 5
			};
			ColumnDefinition c = new ColumnDefinition();
			ColumnDefinition c1 = new ColumnDefinition();
			ColumnDefinition c2 = new ColumnDefinition();

			c.Width = new GridLength(2, GridUnitType.Star);
			innerGrid.ColumnDefinitions.Insert(0, c);

			c1.Width = new GridLength(2, GridUnitType.Star);;
			innerGrid.ColumnDefinitions.Insert(1, c1);

			c2.Width = new GridLength(2, GridUnitType.Star);;
			innerGrid.ColumnDefinitions.Insert(2, c2);

			// Create the profile image
			RoundedBoxView profileImage = new RoundedBoxView {
				Source = profileImageLoc,
				HeightRequest = 100,
				WidthRequest = 100
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
			string dataTimeText = date.ToLocalTime ().ToString ();

			// Setup the label grid that holds the labels name and dateTime
			Grid labelGrid = new Grid {
				Padding = 0
			};

			RowDefinition r = new RowDefinition ();
			r.Height = new GridLength(1, GridUnitType.Star);
			labelGrid.RowDefinitions.Add(r);

			ColumnDefinition c = new ColumnDefinition();
			c.Width = new GridLength(1, GridUnitType.Star);
			labelGrid.ColumnDefinitions.Add (c);

			// Create Labels
			Label name = createFeedLabel (nameText, 16);
			name.FontAttributes = FontAttributes.Bold;
			name.WidthRequest = 500;

			Label dateTime = createFeedLabel (dataTimeText, 12);
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
		private void navigateTo(string email){
			// Database connection

			// Get row with id in ProjectDetailsDB.

			// Open the profile of that page.
		}
	}
}

