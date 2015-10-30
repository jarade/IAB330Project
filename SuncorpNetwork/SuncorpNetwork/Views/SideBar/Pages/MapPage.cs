using System;
using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public class MapPage: BaseView
	{
		MallListView list;
		SearchBar searchbar;

		public MapPage ()
		{
			Title = "Chandler Mall";

			list = new MallListView ();

			searchbar = new SearchBar () {
				Placeholder = "Search",
			};

			searchbar.TextChanged += (sender, e) => list.FilterLocations (searchbar.Text);
			searchbar.SearchButtonPressed += (sender, e) => {
				list.FilterLocations (searchbar.Text);
			};

			var stack = new StackLayout () {
				Children = {
					searchbar,
					list
				}
			};

			Content = stack;
		}
	}
}

