using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SuncorpNetwork
{
	public class MenuListView : ListView
	{
		public List<MenuItem> data { get; set; }

		public MenuListView ()
		{
			List<MenuItem> data = new MenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;

			var cell = new DataTemplate (typeof(sideCustomViewCell));

			ItemTemplate = cell;
		}
	}
}

