using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public class MapPage: BaseView
	{
		MallListView list;
		SearchBar searchbar;

		public MapPage ()
		{
			Title = "Search For a Business";
			BackgroundColor = Color.FromHex("#0DA195");
			list = new MallListView ();

			Grid content = new Grid ();

			RowDefinition r = new RowDefinition ();
			r.Height = new GridLength (2, GridUnitType.Star);
			content.RowDefinitions.Insert (0, r);

			r = new RowDefinition ();
			r.Height = new GridLength (7, GridUnitType.Star);
			content.RowDefinitions.Insert (1, r);

			r = new RowDefinition ();
			r.Height =  new GridLength (1.2, GridUnitType.Star);
			content.RowDefinitions.Insert (2, r);

			searchbar = new SearchBar () {
				Placeholder = "Search",
			};

			searchbar.TextChanged += (sender, e) => list.FilterLocations (searchbar.Text);
			searchbar.SearchButtonPressed += (sender, e) => {
				list.FilterLocations (searchbar.Text);
			};

			var stack = new StackLayout () {
				Children = {
					list
				}
			};
			content.Children.Add (searchbar, 0, 0);
			content.Children.Add (stack, 0, 1);
			content.Children.Add (createFooter (), 0, 2);

			Content = content;
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
