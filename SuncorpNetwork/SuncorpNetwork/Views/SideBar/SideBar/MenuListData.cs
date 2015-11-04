using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Searching Businesses", 
				IconSource = "searching.png",
				TargetType = typeof(MapPage),
				Background = Color.FromHex("#0DA195")
			});

			this.Add (new MenuItem () { 
				Title = "Learning Resources", 
				IconSource = "learning.png",
				TargetType = typeof(Learning_Resources),
				Background = Color.FromHex("#0DA195")
			});

			this.Add (new MenuItem () { 
				Title = "Insurance/Finance", 
				IconSource = "business.png",
				TargetType = typeof(InsuranceFinance),
				Background = Color.FromHex("#0DA195")
			});

			this.Add (new MenuItem () {
				Title = "Forums",
				IconSource = "forums.png",
				TargetType = typeof(Forums),
				Background = Color.FromHex("#0DA195")
			});

			this.Add (new MenuItem () {
				Title = "Settings",
				IconSource = "settings.png",
				TargetType = typeof(Settings),
				Background = Color.FromHex("#0DA195")
			});

			this.Add (new MenuItem () {
				Title = "Contact Us",
				IconSource = "contact.png",
				TargetType = typeof(Contact_Us),
				Background = Color.FromHex("#0DA195")
			});
		}
	}
}

