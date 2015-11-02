using System;
using Xamarin.Forms;
using SuncorpNetwork.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(ImageCell), typeof(CustomListView))]
namespace SuncorpNetwork.Droid
{
	public class CustomListView : ImageCellRenderer
	{
		public CustomListView(){
			
		}
	}
}

