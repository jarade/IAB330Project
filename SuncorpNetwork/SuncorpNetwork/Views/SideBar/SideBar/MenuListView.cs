using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SuncorpNetwork
{
	public class MenuListView : ListView
	{
		public MenuListView ()
		{
			List<MenuItem> data = new MenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.FromHex("#0DA195");

			var cell = new DataTemplate (typeof(ImageCell));
			cell.SetBinding (TextCell.TextProperty, "Title");
			cell.SetBinding (TextCell.TextColorProperty, "TextColour");
			cell.SetBinding (ImageCell.ImageSourceProperty, "IconSource");

			ItemTemplate = cell;
		}
	}
}

