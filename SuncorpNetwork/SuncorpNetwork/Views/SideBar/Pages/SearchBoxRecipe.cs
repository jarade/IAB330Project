using System;
using Xamarin.Forms;

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