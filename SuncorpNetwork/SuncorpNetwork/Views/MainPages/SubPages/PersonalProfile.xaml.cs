using System;
using System.Collections.Generic;
using SuncorpNetwork.Data;
using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class PersonalProfile : ContentPage
	{
		public PersonalDetails TheDetails {	get; set; }

		public PersonalProfile ()
		{
			TheDetails = new PersonalDetails();
			TheDetails.FirstName = "Chou";
			TheDetails.LastName = "Chou";
			TheDetails.Email = "lu.03566@gmail.com";
			TheDetails.Availability = false ;
			if (TheDetails.Availability == false) {
				TheDetails.Availability_2 = "Not Available";
			} else {
				TheDetails.Availability_2 = "Available";
			}

			var database = new PersonalDB ();
			string email = "lu.03566@gmail.com";
			TheDetails.FirstName = "FRED";
			database.InsertOrUpdatePersonalDetails (TheDetails);
			//database.GetDetails (email);
			var items = database.GetItems();
			int p = ((List<PersonalDetails>)items).Count;
			// if p == 1 then do stuff else could not find
			PersonalDetails item = database.GetDetails(email);
			//TheDetails.ProfilePic = ImageSource.FromFile("images.jpg");
			TheDetails.FirstName = item.FirstName;
			//profilePic.Source = "images.jpg"//TheDetails.ProfilePic,

			TheDetails.Pros = "Xamarin,IOS Development, Android Development";
			TheDetails.Overview = "I develop cross-platform mobile apps including games for iOS, Android & Windows platforms. I know everything about mobile development including adnetworks integration, in-app purchases on every platform, social functionality (login/sharing etc), cross-platform back-end services like Parse. oDesk has recognized me as one of their top Mobile Developers. See the badge on the right of my profile for more information ";
			BindingContext = TheDetails;
			InitializeComponent ();
		}


		public PersonalProfile (PersonalDetails other_details)
		{
			if (other_details.Availability == false ) {
				other_details.Availability_2 = "Not Available";
			}

			var database = new PersonalDB ();
			string email = other_details.Email;

			database.InsertOrUpdatePersonalDetails (TheDetails);
			//database.GetDetails (email);
			var items = database.GetItems();
			int p = ((List<PersonalDetails>)items).Count;
			// if p == 1 then do stuff else could not find
			PersonalDetails item = database.GetDetails(email);
			//TheDetails.ProfilePic = ImageSource.FromFile("images.jpg");

			TheDetails.FirstName = item.FirstName;
			//profilePic.Source = "images.jpg"//TheDetails.ProfilePic,

			TheDetails.Pros = "Xamarin,IOS Development, Android Development";
			TheDetails.Overview = "I develop cross-platform mobile apps including games for iOS, Android & Windows platforms. I know everything about mobile development including adnetworks integration, in-app purchases on every platform, social functionality (login/sharing etc), cross-platform back-end services like Parse. oDesk has recognized me as one of their top Mobile Developers. See the badge on the right of my profile for more information ";
			BindingContext = TheDetails;
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

		private void switchPage(Page page){
			SideNavi curNavi = (SideNavi)this.Parent.Parent;
			curNavi.switchTo(page);
		}

		public void MsgBtnClicked(object sender, EventArgs e){
			switchPage(new Messages ());
		}


		public async void FollowBtnClicked(object sender, EventArgs e){
		}

	}
}

