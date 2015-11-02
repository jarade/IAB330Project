using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Forums : ContentPage
	{
		public Forums ()
		{
			InitializeComponent ();
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
		public async void Subforum1Clicked (object sender, EventArgs e)
		{
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(new Forum1());
		}

		private void switchPage(Page page){
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(page);
		}
	}
}

