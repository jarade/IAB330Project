using System;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class App : Application
	{
		public string UserEmail { get; set; }

		public App ()
		{
			MainPage = GetMainPage();// The root page of your application
		}

		public static Page GetMainPage(){
			Page main;
			// if logged in previosly
			// else
			// MainPage = new Login();
			main = new Login();

			return main; 
		
		}
			

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

