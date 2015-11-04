using System;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class RoundedBoxView : Image
	{
		public RoundedBoxView ()
		{
		}

		public static readonly BindableProperty CornerRadiusProperty = 
			BindableProperty.Create < RoundedBoxView, double>(
				p => p.CornerRadius, default(double));

		public double CornerRadius {
			get { return (double)GetValue (CornerRadiusProperty);	}
			set { SetValue (CornerRadiusProperty, value); }
		}
	}
}

