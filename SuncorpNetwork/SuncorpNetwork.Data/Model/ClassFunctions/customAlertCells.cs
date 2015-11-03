using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class customAlertCells : ViewCell
	{
		public StackLayout cellLayout;

		public customAlertCells ()
		{
			Image read = new Image{ };
			read.SetBinding (Image.SourceProperty, "Source");

			Label title = new Label {
				TextColor = Color.White,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
			};
			title.SetBinding (Label.TextProperty, "Title");

			Label type = new Label {
				TextColor = Color.White,
				FontSize = 16,
				FontAttributes = FontAttributes.Italic,
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center,
				WidthRequest = 500
			};
			type.SetBinding (Label.TextProperty, "GetType");

			Label poster = new Label {
				TextColor = Color.White,
				FontSize = 12,
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center,
			};
			poster.SetBinding (Label.TextProperty, "Poster");

			Label date = new Label {
				TextColor = Color.White,
				FontSize = 10,
				XAlign = TextAlignment.End,
				YAlign = TextAlignment.Center,
			};
			date.SetBinding (Label.TextProperty, "timeStamp");

			StackLayout labelLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical, 
				Spacing = 5,
				Padding = 5
			};
			labelLayout.Children.Add (title);
			labelLayout.Children.Add (type);
			labelLayout.Children.Add (poster);
			labelLayout.Children.Add (date);

			StackLayout cellLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 5,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Padding = 5
			};
			try{
				cellLayout.SetBinding (StackLayout.BackgroundColorProperty, "Background");
			}catch(Exception e){
				// ignore it
			}
			cellLayout.Children.Add (read);
			cellLayout.Children.Add (labelLayout);

			this.View = cellLayout;
		}
	}
}

