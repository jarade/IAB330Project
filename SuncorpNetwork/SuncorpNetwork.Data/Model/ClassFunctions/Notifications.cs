/**	File: Notifications.cs - A class containing properties for the
 * 									Alerts list.
 * 	Created: 30/09/2015
 *	Original Author: Jarrod Eades N8855722 
 **/
using System;
using Xamarin.Forms;
using SQLite.Net.Attributes;

namespace SuncorpNetwork.Data
{
	public class Notification
	{
		private string compositePrimaryKey;
		[PrimaryKey]
		public string CompositePrimaryKey {
			get{ return compositePrimaryKey; }
			set{ compositePrimaryKey = value; }
		} 
		public string PosterEmail { get; set; }
		private string poster;
		public string Poster { 
			get{ return poster; } 
			set{ poster = value; }
		}

		public string Title { get; set; }

		public bool HasRead { get; set; }

		private DateTime timestamp;
		public DateTime TimeStamp { get{ return timestamp; } set{ timestamp = value; } }
		public string timeStamp {
			get{ return timestamp.ToLocalTime ().ToString (); }
		}

		private string type;
		public string Type { get{ return type; } set{ type = value;}}
		// To prevent overwritting itself, made a new getter for it
		public string GetType { get { return "Type: " + type; } }
		public string Source { get; set; }

		[Ignore]
		public Color Background { 
			get {
				if (HasRead) {
					return Color.FromHex("#007064"); 
				} else {
					return Color.FromHex ("#0DA195");
				}
			}
		}
		public Notification ()
		{
		}
	}
}

