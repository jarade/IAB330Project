using System;
using Xamarin.Forms;
using SuncorpNetwork;

namespace SearchBoxRecipe
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage(new MapPage());
		}
	}
}