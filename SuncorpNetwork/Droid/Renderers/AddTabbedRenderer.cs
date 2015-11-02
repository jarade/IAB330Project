using System;
using Xamarin.Forms;
using SuncorpNetwork.Droid;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(AddTabbedRenderer))]
namespace SuncorpNetwork.Droid
{
	public class AddTabbedRenderer : TabbedRenderer
	{
		private const string COLOUR = "#0DA195";
		private Activity activity;

		public AddTabbedRenderer(){
			activity = this.Context as Activity;
			ActionBar actionBar = activity.ActionBar;
			ColorDrawable colorDrawable = new ColorDrawable(Android.Graphics.Color.ParseColor(COLOUR));
			actionBar.SetStackedBackgroundDrawable(colorDrawable);
		}

	}
}

