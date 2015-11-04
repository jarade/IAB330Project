using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using SuncorpNetwork;
using SuncorpNetwork.Droid;
using Android.Graphics;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxRendered))]
namespace SuncorpNetwork.Droid
{
	public class RoundedBoxRendered : ImageRenderer
	{
		public RoundedBoxRendered ()
		{
		}

		protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
		{
			try
			{
				var radius = Math.Min(Width, Height) / 2;
				var strokeWidth = 10;
				radius -= strokeWidth / 2;

				//Create path to clip
				var path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
				canvas.Save();
				canvas.ClipPath(path);

				var result = base.DrawChild(canvas, child, drawingTime);

				canvas.Restore();

				// Create path for circle border
				path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

				var paint = new Paint();
				paint.AntiAlias = true;
				paint.StrokeWidth = 5;
				paint.SetStyle(Paint.Style.Stroke);
				paint.Color = global::Android.Graphics.Color.White;

				canvas.DrawPath(path, paint);

				//Properly dispose
				paint.Dispose();
				path.Dispose();
				return result;
			}
			catch (Exception ex)
			{
			}

			return base.DrawChild(canvas, child, drawingTime);
		}
	}
}

