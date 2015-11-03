using System;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class MenuPage : ContentPage
	{
		public MenuListView Menu { get; set; }

		public MenuPage ()
		{
			Icon = "profile_filler.png";//"settings.png";
			Title = "menu"; // The Title property must be set.
			BackgroundColor = Color.FromHex ("#007064");

			Menu = new MenuListView ();

			var menuLabel = new ContentView {
				Padding = 10,
				Content = new Label {
					TextColor = Color.White,
					Text = "Menu",
					XAlign = TextAlignment.Center,
					FontSize = 20,
					FontAttributes = FontAttributes.Bold
				}
			};

			StackLayout layout = new StackLayout { 
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Spacing = 0
			};

			layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
}


