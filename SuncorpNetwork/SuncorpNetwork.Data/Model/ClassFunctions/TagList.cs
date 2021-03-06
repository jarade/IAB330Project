﻿using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace SuncorpNetwork.Data
{
	public class TagList
	{
		public Dictionary<string, bool> tagChecked = new Dictionary<string, bool>();

		public TagList(){
			initDictionary ();
		}
			
		private void initDictionary (){
			var database = new TagDatabase ();
			//database.DeleteAllItems (); // For testing purposes
			var databaseItems = database.GetItems ().OrderBy (x => x.TagName);

			foreach (Tag item in databaseItems) {
				tagChecked.Add (item.TagName, false);
			}
		}

		public void addToDictionary(string key){
			tagChecked.Add (key, false);
		}
		/** Initialise the tags array from the database.
		 * 		Also initialises the gotTags Dictionary.
		 *	Post: tags[] - the list of tags to use.
		 **/
		public Tags[] initTags(){
			int arraySize = tagChecked.Count();
			Tags[] tempTagArr = new Tags [arraySize];
			int index = 0;

			foreach (string item in tagChecked.Keys) {
				bool isChecked; 
				tagChecked.TryGetValue (item, out isChecked);
				tempTagArr [index] = new Tags(item, isChecked);
				index++;
			}

			return tempTagArr;
		}

		/** Create Tag List stack
		 **/
		public StackLayout createTagListStack (Button done){
			// Initialise tags
			Tags[] tagAr = initTags ();

			// Create the shown elements
			ListView lView = new ListView {
				BackgroundColor = Color.FromHex("#007064"),
			};

			// Setup those elements
			lView.ItemSelected += noSelection;
			lView.ItemTapped += tappedSelection;

			DataTemplate template = new DataTemplate (typeof (customCellTags));

			lView.ItemsSource = tagAr;
			lView.ItemTemplate = template;
		
			// Create the layout to show those elements
			StackLayout options = new StackLayout {
				Spacing = 15,
				Padding = new Thickness(15,15,15,15),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Children = {lView, done}
			};
			return options;
		}

		/**	Mark the selection to checked/unchecked 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event argument - convert e.Item to tags class
		 **/
		public void tappedSelection(object sender, ItemTappedEventArgs e){
			((Tags)e.Item).isChecked = !((Tags)e.Item).isChecked;
			((ListView)sender).ItemTemplate = new DataTemplate (typeof (customCellTags));
			tagChecked.Remove (((Tags)e.Item).Name); 
			tagChecked.Add(((Tags)e.Item).Name, ((Tags)e.Item).isChecked);
		}
		/**	Disable the selection event for the tag selection 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		public void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}
	}
}

