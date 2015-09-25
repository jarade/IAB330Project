/**	File: Tags.cs - A class containing properties for the tag search list. Was refactored from Home.xaml.cs.
 * 	Created: 25/09/2015
 *	Original Author: Jarrod Eades N8855722 
 **/
using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	/**	A class for the tag search list
	 **/
	public class Tags{
		public Tags (){
		}

		/** Is identifier.
		 **/
		public string Name {
			get;
			set;
		}

		public Color TextColour {
			get;
			set;
		}

		public bool isChecked {
			get;
			set;
		}

		public String checkImage {
			get {
				String sourceImageFileName;

				// If checked image needs to be displayed
				if (isChecked) {
					sourceImageFileName = "profile_filler.png";//"checked.png";
				} else {
					sourceImageFileName = "icon.png";//"unchecked.png";
				}

				return sourceImageFileName;
			}

			set { }
		}
	}
}

