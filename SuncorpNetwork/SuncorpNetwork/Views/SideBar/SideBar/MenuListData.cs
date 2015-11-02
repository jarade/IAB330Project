using System;
using System.Collections.Generic;

namespace SuncorpNetwork
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Searching Businesses", 
				IconSource = "icon.png",
				TargetType = typeof(MapPage)
			});

			this.Add (new MenuItem () { 
				Title = "Learning Resources", 
				IconSource = "icon.png",
				TargetType = typeof(Learning_Resources)
			});

			this.Add (new MenuItem () { 
				Title = "Insurance/Finance", 
				IconSource = "icon.png",
				TargetType = typeof(InsuranceFinance)
			});

			this.Add (new MenuItem () {
				Title = "Forums",
				IconSource = "icon.png",
				TargetType = typeof(Forums)
			});

			this.Add (new MenuItem () {
				Title = "Settings",
				IconSource = "icon.png",
				TargetType = typeof(Settings)
			});

			this.Add (new MenuItem () {
				Title = "Contact Us",
				IconSource = "icon.png",
				TargetType = typeof(Contact_Us)
			});
		}
	}
}

