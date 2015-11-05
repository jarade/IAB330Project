using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class EditProfile : ContentPage
	{
		public EditProfile ()
		{
			InitializeComponent ();
		}
		public void messageBtnClicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Messages ());
		}

		public void SaveClicked(object sender, EventArgs e){
			// Navigate to the Page.
			DisplayAlert("Edit Saved!", "You have successfully made the changes!", "OK");
			switchPage(new PersonalProfile ());
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

