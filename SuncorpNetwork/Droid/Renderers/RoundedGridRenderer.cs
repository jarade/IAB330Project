using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SuncorpNetwork;
using SuncorpNetwork.Droid;
using Android.Graphics;

[assembly: ExportRenderer (typeof (RoundedGrid), typeof (RoundedGridRenderer))]
namespace SuncorpNetwork.Droid
{	
	public class RoundedGridRenderer : ViewRenderer
	{
		public RoundedGridRenderer ()
		{
		}

		public override void Draw(Canvas canvas){
			RoundedGrid rg = (RoundedGrid)this.Element;

			Rect rc = new Rect ();
			GetDrawingRect (rc);

			Rect interior = rc;
			interior.Inset((int)rg.StrokeThickness, (int)rg.StrokeThickness);

			Paint p = new Paint () {
				Color = rg.BackgroundColor.ToAndroid(),
				AntiAlias = true
			};

			canvas.DrawRoundRect (new RectF (interior), (float)rg.CornerRadius, (float)rg.CornerRadius, p);

			p.Color = rg.Stroke.ToAndroid ();
			p.StrokeWidth = (float)rg.StrokeThickness;
			p.SetStyle(Paint.Style.Stroke);

			canvas.DrawRoundRect(new RectF(rc), (float)rg.CornerRadius, (float)rg.CornerRadius, p);
		}
	}
}

