using System;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace SuncorpNetwork.Data
{
	public class IAlertBackgroundColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture){
			string hex = value.ToString();
			return Color.FromHex (hex);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){
			Color colour = (Color)value;
			Debug.WriteLine ("Colour: " + colour.ToString ());
			return colour.ToString ();
		}
	}
}

