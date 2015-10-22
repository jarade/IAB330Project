using System;
using GalaSoft.MvvmLight;
using SuncorpNetwork;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class AddViewModel : ViewModelBase
	{
		public StackLayout createTagChoice(){
			StackLayout s = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal
			};

			Label l = new Label{
				Text = "Tag:\t",
				TextColor = Color.White, 
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			Button b = new Button {
				Text = "Choose",
				TextColor = Color.Black,
				BackgroundColor = Color.White
			};

			s.Children.Add (l);
			s.Children.Add (b);

			return s;
		}


	}
}

