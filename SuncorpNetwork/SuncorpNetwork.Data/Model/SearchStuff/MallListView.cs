using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using SearchBoxRecipe;

namespace SuncorpNetwork.Data
{
	public class MallListView : ListView
	{
		List<Location> locations;

		public MallListView ()
		{
			locations = new Locations ();

			var cell = new DataTemplate (typeof(TextCell));

			cell.SetBinding (TextCell.TextProperty, "Title");
			cell.SetBinding (TextCell.DetailProperty, "Subtitle");

			ItemTemplate = cell;

			ItemsSource = locations;

			ItemSelected += (s, e) => {
				if (SelectedItem == null)
					return;
				var selected = (Location)e.SelectedItem;
				SelectedItem = null;
				//Navigation.PushAsync (new CampusLocationPage (selected));
			};
		}

		public void FilterLocations (string filter)
		{
			//this.BeginRefresh ();

			if (string.IsNullOrWhiteSpace (filter)) {
				this.ItemsSource = locations;
			} else {
				this.ItemsSource = locations
					.Where (x => x.Title.ToLower ()
						.Contains (filter.ToLower ()));
			}

			//this.EndRefresh ();
		}

	}
}

