using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Alert : ContentPage
	{

		public Alert ()
		{
			DisplayAlert ("Email", "There is no email", "OK");
			InitializeComponent ();
			listNotifications ();
		}

		private Notification[] createAlerts(){
			Notification noteNotRead = new Notification {
				Title = "Test Not Read", 
				Details = "This is a test notification.",
				HasRead = false,
			};

			Notification noteRead = new Notification{
			Title = "Test Read",
			Details = "This is a test notification.",
			HasRead = true,
			};

			Notification longNoteUnread = new Notification{
				Title = "Test Long and Not Read",
				Details = "This is a test notification. This notification has alot more text than the others. That is what makes this a long notification.",
				HasRead = false,
			};

			Notification[] notes = {
				longNoteUnread,
				noteNotRead, noteNotRead, noteNotRead, noteNotRead,
				noteRead, noteRead, noteRead,
			};
				
			return notes;
		}

		private void listNotifications(){
			Notification[] notificationsArr = createAlerts ();
			ListView notificationList = new ListView {
				BackgroundColor = Color.Black,
				HasUnevenRows = true
			};

			notificationList.ItemsSource = notificationsArr;
			notificationList.ItemTemplate = listViewData();
			notificationList.ItemSelected += noSelection;
			notificationList.ItemTapped += tappedSelection;
			NotificationListSection.Children.Add (notificationList);
		}

		/**	Mark the selection to read
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event argument - convert e.Item to tags class
		 **/
		private void tappedSelection(object sender, ItemTappedEventArgs e){
			((Notification)e.Item).HasRead = true;
			((ListView)sender).ItemTemplate = listViewData();
		}

		/**	Disable the selection event for the tag selection 
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event arguments.
		 **/
		private void noSelection (object sender, SelectedItemChangedEventArgs e){
			((ListView)sender).SelectedItem = null;
		}

		/** Create a DataTemplate for the list view.
		 * 	Post: DataTemplate - the newly created DataTemplate
		 **/
		private DataTemplate listViewData(){
			DataTemplate template = new DataTemplate (typeof (ImageCell));
			template.SetBinding(ImageCell.TextProperty, "Title");
			template.SetBinding (ImageCell.DetailProperty, "Details");
			template.SetBinding (ImageCell.ImageSourceProperty, "HasReadIconSource");

			return template;
		}

		public void messageBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Messages ());
		}

		public void alertBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Alert ());
		}

		public void homeBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Home ());
		}

		public void addBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Add ());
		}

		public void profileBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new PersonalProfile ());
		}

		private void switchPage(Page page){
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(page);
		}
	}
}

