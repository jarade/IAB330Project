using System;
using Xamarin.Forms;

namespace SuncorpNetwork.Data
{
	public class TagList
	{
		/** Initialise the tags array from the database.
		 * 		Also initialises the gotTags Dictionary.
		 *	Post: tags[] - the list of tags to use.
		 **/
		public Tags[] initTags(){
			// Setup tags array
			Tags[] tempTagAr = {
				new Tags{Name = "IT", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Education", TextColour = Color.White, isChecked = false},
				new Tags{Name = "Website", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Construction", TextColour = Color.White, isChecked = false}, 
				new Tags{Name = "Etc", TextColour = Color.White, isChecked = false}
			};

			return tempTagAr;
		}

		/**	Mark the selection to checked/unchecked 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event argument - convert e.Item to tags class
		 **/
		public void tappedSelection(object sender, ItemTappedEventArgs e){
			((Tags)e.Item).isChecked = !((Tags)e.Item).isChecked;
			((ListView)sender).ItemTemplate = tagsChoiceListViewData();
		}
		/**	Disable the selection event for the tag selection 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		public void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}

		/** Create a DataTemplate for the tags list view.
		 * 	Post: DataTemplate - the newly created DataTemplate
		 **/
		public DataTemplate tagsChoiceListViewData(){
			DataTemplate template = new DataTemplate (typeof (ImageCell));

			template.SetBinding(ImageCell.TextProperty, "Name");
			template.SetBinding(ImageCell.TextColorProperty, "TextColour");
			template.SetBinding (ImageCell.ImageSourceProperty, "checkImage");

			return template;
		}
	}
}

