using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Project : BaseView
	{
		public Project ()
		{
			InitializeComponent ();
		}

		public Project (int ID)
		{
			InitializeComponent ();
			var projectDetailsTable = new ProjectDetailsDatabase ();
			ProjectDetails pd = projectDetailsTable.GetItemWithId (ID);

			this.BindingContext = pd;
			DisplayAlert (pd.Title, pd.Information, pd.FirstName);
			this.SetBinding (TitleProperty, "Title");
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

