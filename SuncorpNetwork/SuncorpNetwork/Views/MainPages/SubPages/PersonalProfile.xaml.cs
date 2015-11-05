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

			setup ();
		}

		public void setup(){
			var database = new PersonalDB ();
			PersonalDetails item = database.GetDetails(((App)Application.Current).UserEmail);
			item.ProfilePic = "images.jpg";

			//TheDetails.FirstName = item.FirstName;
			//profilePic.Source = "images.jpg"//TheDetails.ProfilePic,
			item.Availability_2 = "Busy";
			item.Pros = "Xamarin,IOS Development, Android Development";
			item.Overview = "I develop cross-platform mobile apps including games for iOS, Android & Windows platforms. I know everything about mobile development including adnetworks integration, in-app purchases on every platform, social functionality (login/sharing etc), cross-platform back-end services like Parse. oDesk has recognized me as one of their top Mobile Developers. See the badge on the right of my profile for more information ";

			BindingContext = item;
			InitializeComponent ();
			var pic = new RoundedBoxView(){
				WidthRequest = 100,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
			};
			pic.SetBinding (RoundedBoxView.SourceProperty, "ProfilePic");

			Content.Children.Insert (0, pic);

			var pic2 = new RoundedBoxView(){
				WidthRequest = 45,
				HeightRequest = 45,
				HorizontalOptions = LayoutOptions.Center,
			};
			pic2.Source = ImageSource.FromFile("xen.jpg");

			History1.Children.Insert (0, pic2);


		}

		public void EditBtn(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new EditProfile ());
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

