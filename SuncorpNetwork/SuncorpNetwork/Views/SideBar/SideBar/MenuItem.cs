using System;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public class MenuItem{
		public string Title {get; set;}
		public Color TextColour { get{ return Color.White; } }
		public Color Background { get; set; }
		public string IconSource { get; set;}
		public Type TargetType { get; set;}
	}
}

