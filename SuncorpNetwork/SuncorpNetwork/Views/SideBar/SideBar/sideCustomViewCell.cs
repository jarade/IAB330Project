using System;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class sideCustomViewCell : ViewCell
	{
		public sideCustomViewCell ()
		{
			StackLayout s = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal,
				Padding = 10,
				Spacing = 10
			};
			s.SetBinding (StackLayout.BackgroundColorProperty, "Background");

			Label l = new Label {
				FontSize = 17,
				FontAttributes = FontAttributes.Bold,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};
			l.SetBinding (Label.TextProperty, "Title");
			l.SetBinding (Label.TextColorProperty, "TextColour");

			Image i = new Image {
			};
			i.SetBinding (Image.SourceProperty, "IconSource");

			s.Children.Add (i);
			s.Children.Add (l);

			this.View = s;
		}
	}
}

