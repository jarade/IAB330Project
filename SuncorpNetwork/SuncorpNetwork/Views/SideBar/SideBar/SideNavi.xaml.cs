using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;

namespace SuncorpNetwork
{
	public partial class SideNavi : MasterDetailPage
	{
		private MenuPage menuPage { get; set; }
		public SideNavi ()
		{
			menuPage = new MenuPage ();
			menuPage.BackgroundColor = Color.FromHex("#007064");
			menuPage.Icon = "menu.png";

			menuPage.Menu.ItemSelected += (sender, e) => {
				// Reset the colour of the list items
				var items = menuPage.Menu.ItemsSource;
				foreach(MenuItem item in items){
					item.Background = Color.FromHex("#0DA195");
				}

				if(e.SelectedItem != null){
					// Set the new colour of the selected item
					((MenuItem)e.SelectedItem).Background = Color.FromHex("#007064");

					// Change page
					NavigateTo (e.SelectedItem as MenuItem);
				}

				// Refresh the datatemplate
				menuPage.Menu.ItemTemplate = new DataTemplate(typeof(sideCustomViewCell));
			};

			Master = menuPage;
			Detail = setupPage(new Home());
		}

		public void NavigateTo (MenuItem menu){
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
			Detail = setupPage(displayPage);

			IsPresented = false;
		}

		public void switchTo(Page displayPage){
			// Deselect Item in list
			menuPage.Menu.SelectedItem = null;

			Detail = setupPage(displayPage);

			MasterBehavior = MasterBehavior.Popover;
			IsPresented = false;
		}

		private NavigationPage setupPage(Page displayPage){
			var page = new NavigationPage (displayPage);
			page.Icon = "menu.png"; // Change this
			page.BarBackgroundColor = Color.FromHex("#007064");
			page.BarTextColor = Color.White;
			BackgroundColor = Color.FromHex("#007064");
			page.HeightRequest = 100;
			return page;
		}
	}
}