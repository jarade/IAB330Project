using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using SuncorpNetwork.Data;
using SuncorpNetwork.Droid;

[assembly: ExportRenderer (typeof (MyEditor), typeof (MyEditorRenderer))]
namespace SuncorpNetwork.Droid
{
	public class MyEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.White);
				Control.SetTextColor(global::Android.Graphics.Color.Black);
			}
		}
	}
}

