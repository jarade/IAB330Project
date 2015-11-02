using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace SuncorpNetwork
{
	public partial class SideNavi : MasterDetailPage
	{
		public SideNavi ()
		{
			var menuPage = new MenuPage ();
			menuPage.BackgroundColor = Color.FromHex("#007064");
			menuPage.Menu.BackgroundColor = Color.FromHex("#0DA195");
			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);
			Master = menuPage;
			Detail = setupPage(new Home());
		}

		public SideNavi (string email)
		{
			var menuPage = new MenuPage ();
			menuPage.BackgroundColor = Color.FromHex("#0DA195");
			menuPage.Menu.BackgroundColor = Color.FromHex("#0DA195");

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);
			Master = menuPage;
			Detail = setupPage(new Home());
		}

		public void NavigateTo (MenuItem menu){
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
			Detail = setupPage(displayPage);

			IsPresented = false;
		}

		public void switchTo(Page displayPage){
			Detail = setupPage(displayPage);

			IsPresented = false;
		}

		private NavigationPage setupPage(Page displayPage){
			var page = new NavigationPage (displayPage);
			page.Icon = "profile_filler.png";
			page.BarBackgroundColor = Color.FromHex("#007064");
			page.BarTextColor = Color.White;
			page.HeightRequest = 75;
			return page;
		}
	}
}