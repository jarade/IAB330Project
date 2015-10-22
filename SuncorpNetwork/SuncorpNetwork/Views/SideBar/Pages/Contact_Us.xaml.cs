using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Contact_Us : BaseView
	{
		MyEditor subjectEditor;

		public Contact_Us ()
		{
			InitializeComponent ();

			createCustomEditor ();
			problemPicker.SelectedIndex = 0;
		}

		private void createCustomEditor(){
			subjectEditor = new MyEditor ();
			subjectEditor.WidthRequest = 400;
			subjectEditor.HeightRequest = 200;
			subjectSection.Children.Add (subjectEditor);
		}

		public void send(object sender, EventArgs e){
			if ((emailAddress.Text != "" && respondSwitch.IsToggled) || !respondSwitch.IsToggled) {
				if (problemPicker.SelectedIndex != 0) {
					if (subjectEditor.Text != "") {
						DisplayAlert ("Sent", "The message has been sent", "Ok");

						// Navigate to the Home Page.
						switchPage (new Home ());
					} else {
						DisplayAlert ("Error", "The subject has not been provided", "Back");
					}
				} else {
					DisplayAlert ("Error", "The Type of Problem has not been provided", "Back");
				}
			} else {
				DisplayAlert ("Error", "The email address has not been provided", "Back");
			}
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

