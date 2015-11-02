using System;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage ()
		{
			Icon = "profile_filler.png";//"settings.png";
			Title = "menu"; // The Title property must be set.
			BackgroundColor = Color.FromHex ("333333");

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

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
}


