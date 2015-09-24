using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Home : ContentPage
	{
		private Dictionary<string, int> gotTags = new Dictionary<string, int>();
		private string[] sortBy = {"Recent", "Interests"};
		private bool tagLock = false;
		tags[] tagAr;

		public Home ()
		{
			InitializeComponent ();
			createSearchBy ();
			createNewsPost ();
			TagsBtn.Clicked += tagBtnOnClick;
		}
			
		public void createSearchBy(){
			foreach (string sort in sortBy)
			{
				SortByPicker.Items.Add(sort);
			}
			SortByPicker.BackgroundColor = Color.Black;
			SortByPicker.Title = SortByPicker.Items [0];
		}

		private tags[] initTags(){
			// Get tags from database...
			tags[] tempTagAr = {
				new tags{Name = "IT", TextColour = Color.White, isChecked = false}, 
				new tags{Name = "Education", TextColour = Color.White, isChecked = false},
				new tags{Name = "Website", TextColour = Color.White, isChecked = false}, 
				new tags{Name = "Construction", TextColour = Color.White, isChecked = false}, 
				new tags{Name = "Etc", TextColour = Color.White, isChecked = false}
			};

			int index = 0;
			foreach (tags tag in tempTagAr) {
				if (!gotTags.ContainsKey (tag.Name)) {
					gotTags.Add (tag.Name, index);
					index++;
				}
			}

			return tempTagAr;
		}

		private void createTagChoices(){
			tagAr = initTags ();

			ListView lView = new ListView {
				BackgroundColor = Color.Black
			};

			// SimpleListItemChecked
			Button done = new Button {
				Text = "Done"
			};

			lView.ItemSelected += noSelection;
			lView.ItemTapped += tappedSelection;
			done.Clicked += sendBack;

			DataTemplate template = new DataTemplate (typeof (ImageCell));
				
			template.SetBinding(ImageCell.TextProperty, "Name");
			template.SetBinding(ImageCell.TextColorProperty, "TextColour");
			template.SetBinding (ImageCell.ImageSourceProperty, "checkImage");
			//template.SetBinding (TextCell.TextProperty, "Name");
			//template.SetBinding (TextCell.TextColorProperty, "TextColour");

			lView.ItemsSource = tagAr;
			lView.ItemTemplate = template;

			StackLayout options = new StackLayout {
				Spacing = 10,
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Start,
				Children = {lView, done}
			};

			this.Navigation.PushModalAsync (new ContentPage {
				Content = options
			});
		}

		private void sendBack(object sender, EventArgs e){
			this.Navigation.PopModalAsync ();
			tagLock = false;
		}

		private void tappedSelection(object sender, ItemTappedEventArgs e){
			int thisTag; // ((tags)e.Item).Name == gives string id name
			gotTags.TryGetValue(((tags)e.Item).Name.ToString(), out thisTag);
			tagAr [thisTag].isChecked = !tagAr [thisTag].isChecked;

			//DisplayAlert ("Tapped", 
			//	tagAr [thisTag].TextColour.ToString(), "Done");
			
		}

		/**	Disable the selection event for the tag selection 
		 **/
		private void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}

		private void tagBtnOnClick(object sender, EventArgs e){
			if(!tagLock){
				tagLock = true;
				createTagChoices ();
			}
		}
			
		public void createNewsPost(){
			// These will be from the database...
			// string mssage = "This message will be displayed as a message. It will be replaced by the database text.";
			//string name = "Jarrod Eades";
			//Image image;

//			var grid = new Grid {
//				RowSpacing = 20
//			};
		}
	}

	/**	A class for the tags to set colour, if it is checked as its id is Name.
	 **/
	public class tags{
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
				if (isChecked) {
					sourceImageFileName = "icon.png";//"checked.png";
				}else{
					sourceImageFileName = "profile_filler.png";//"unchecked.png";
				}

				return sourceImageFileName;
			}
		}
	}
}

