using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;
using System.Diagnostics;
using System.Linq;

namespace SuncorpNetwork
{
	public partial class Alert : ContentPage
	{

		public Alert ()
		{
			InitializeComponent ();
			listNotifications ();
		}

		//string dataTimeText = date.ToLocalTime ().ToString ();

		private List<Notification> createAlerts(){

			try{
				var database = new NotificationsTable ();
				//database.DeleteAllItems();
				var items = database.GetItemsWithout (((App)Application.Current).UserEmail).OrderByDescending(x => x.TimeStamp).ToList();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Exception: " + e.ToString ());
			}
			List<Notification> notes = new List<Notification> ();
			return notes;
		}

		private void listNotifications(){
			try{
				List<Notification> notifications = createAlerts ();
				ListView notificationList = new ListView {
					BackgroundColor = Color.FromHex("#007064"),
					HasUnevenRows = true
				};

				notificationList.ItemsSource = notifications;

				notificationList.ItemTemplate = listViewData();

				// Set events
				notificationList.ItemSelected += noSelection;
				notificationList.ItemTapped += tappedSelection;

				NotificationListSection.Children.Add (notificationList);
				}catch(Exception e){
					Debug.WriteLine ("Exception: " + e.ToString());
				}
		}

		/**	Mark the selection to read
		 * 	Pre: 	Object: the object that calls this event
		 * 			SelectedItemChangedEventArgs: The event argument - convert e.Item to tags class
		 **/
		private void tappedSelection(object sender, ItemTappedEventArgs e){
			((Notification)e.Item).HasRead = true;
			((Notification)e.Item).Source = "read.png";
			var notiDB = new NotificationsTable ();
			notiDB.InsertOrUpdate ((Notification)e.Item);

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
			DataTemplate template = new DataTemplate (typeof (customAlertCells));
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

