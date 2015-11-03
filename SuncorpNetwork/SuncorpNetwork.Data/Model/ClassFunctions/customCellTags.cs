using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class customCellTags : ViewCell
	{
		public customCellTags ()
		{
			Label l = new Label{
				FontSize = 18,
				FontAttributes = FontAttributes.Bold,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				WidthRequest = 200
			};

			l.SetBinding (Label.TextProperty, "Name");
			l.SetBinding (Label.TextColorProperty, "TextColour");

			Image i = new Image {
			};

			i.SetBinding (Image.SourceProperty, "checkImage");

			StackLayout cellLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 20,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Padding = 5
			};

			cellLayout.Children.Add (i);
			cellLayout.Children.Add (l);

			this.View = cellLayout;
		}
	}
}

