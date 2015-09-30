﻿using System;
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

			Detail = setupPage(new Home());
		}

		public void NavigateTo (MenuItem menu){
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);
			Detail =setupPage(displayPage);

			IsPresented = false;
		}

		public void switchTo(Page displayPage){
			Detail = setupPage(displayPage);

			IsPresented = false;
		}

		private NavigationPage setupPage(Page displayPage){
			var page = new NavigationPage (displayPage);
			page.BarBackgroundColor = Color.FromHex("#007064");
			page.HeightRequest = 50;
			return page;
		}
	}
}