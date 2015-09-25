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
			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);
			Master = menuPage;

			var homePage = new NavigationPage (new Home ());
			homePage.BarBackgroundColor = Color.FromHex("#007064");
			homePage.HeightRequest = 50;
			Detail = homePage;
		}

		private void NavigateTo (MenuItem menu){
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
			Detail = new NavigationPage (displayPage);

			IsPresented = false;
		}
	}
}