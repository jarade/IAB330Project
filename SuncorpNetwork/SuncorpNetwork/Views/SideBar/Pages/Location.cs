using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace SearchBoxRecipe
{

	public class Location
	{
		public string Title { get; set; }

		public string Subtitle { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public Location (string title, string subtitle)
		{
			this.Title = title;
			this.Subtitle = subtitle;
		}
	}
	
}