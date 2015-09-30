/**	File: Notifications.cs - A class containing properties for the
 * 									Alerts list.
 * 	Created: 30/09/2015
 *	Original Author: Jarrod Eades N8855722 
 **/
using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class Notification
	{
		public Notification ()
		{
		}

		public string Title {
			get;
			set;
		}

		public string Details {
			get;
			set;
		}

		public bool HasRead {
			get;
			set;
		}

		public string HasReadIconSource {
			get{
				string sourceImageFileName;

				// If checked image needs to be displayed
				if (HasRead) {
					sourceImageFileName = "profile_filler.png";//"read.png";
				} else {
					sourceImageFileName = "icon.png";//"unread.png";
				}

				return sourceImageFileName;
			}
		}

		public Color HasReadBkgColour {
			get{
				Color bkgColour;

				// If checked image needs to be displayed
				if (HasRead) {
					bkgColour = Color.Black;
				} else {
					bkgColour = Color.Gray;
				}

				return bkgColour;
			}
		}
	}
}

