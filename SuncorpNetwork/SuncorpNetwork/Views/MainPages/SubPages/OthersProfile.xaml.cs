using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class OthersProfile : ContentPage
	{
		public PersonalDetails TheDetails {	get; set; }

		public OthersProfile ()
		{
			var database = new PersonalDB ();
			PersonalDetails item = database.GetDetails("testingemail2@email.com");

			if (((App)Application.Current).UserEmail == "testingemail2@email.com") {
				item.ProfilePic = "profile_pic1.jpg";
			} 

			else if (((App)Application.Current).UserEmail == "testingemail3@email.com") {
				item.ProfilePic = "xen.jpg";
			}

			else 
			{
				item.ProfilePic = "profile_filler.png";
			}

			item.Pros = "Engineering consulting and support";
			item.Overview = "Aerospace and systems engineering consultant and experienced aerodynamicist with almost 40 years of experience with contributions in the development of advanced aircraft configurations, basic aerodynamics research, low-speed stability and control, V/STOL aerodynamics, wind turbine aerodynamics, hydrokinetic energy systems, lighter-than-air vehicles, and wind tunnel test techniques. Experienced in a number of NASA and commercial wind tunnels. Technical work includes aircraft design, vertical wind tunnel design and analysis, aerodynamics of lighter-than-air vehicles, wind turbine aerodynamics, and design/testing of hydrokinetic energy systems. Experienced in the development of both commercial and Government RFPs and proposals.";
			BindingContext = item;
			setup (item);
		}

		public OthersProfile(string email){
			var database = new PersonalDB ();
			PersonalDetails item = database.GetDetails(email);

			// Because we didn't get the image gallery thing working, we have implemented hardcoded images for our testing profiles.
			if (email == "testingemail2@email.com") {
				item.ProfilePic = "profile_pic1.jpg";
			} 

			else if (email == "testingemail3@email.com") {
				item.ProfilePic = "xen.jpg";
			}

			else 
			{
				item.ProfilePic = "profile_filler.png";
			}

			item.Pros = "Engineering consulting and support";
			item.Overview = "Aerospace and systems engineering consultant and experienced aerodynamicist with almost 40 years of experience with contributions in the development of advanced aircraft configurations, basic aerodynamics research, low-speed stability and control, V/STOL aerodynamics, wind turbine aerodynamics, hydrokinetic energy systems, lighter-than-air vehicles, and wind tunnel test techniques. Experienced in a number of NASA and commercial wind tunnels. Technical work includes aircraft design, vertical wind tunnel design and analysis, aerodynamics of lighter-than-air vehicles, wind turbine aerodynamics, and design/testing of hydrokinetic energy systems. Experienced in the development of both commercial and Government RFPs and proposals.";
			BindingContext = item;
			setup (item);
		}

		public void setup(PersonalDetails item){
			
			//TheDetails.FirstName = item.FirstName;
			//profilePic.Source = "images.jpg"//TheDetails.ProfilePic,
			InitializeComponent ();

			var pic = new RoundedBoxView(){
				WidthRequest = 100,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
			};
				pic.SetBinding (RoundedBoxView.SourceProperty, "ProfilePic");

			Content.Children.Insert (0, pic);

			if (((App)Application.Current).UserEmail == item.Email) {
				MsgBtn.IsVisible = false;
				FollowBtn.IsVisible = false;
			} else {
				EditBtn.IsVisible = false;
			}
		}

		public void EditBtnCLicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new EditProfile ());
		}

		public void FollowBtnCLicked(object sender, EventArgs e){
			// Navigate to the Page.
			DisplayAlert("Followed", "You have successfully followed this guy!", "OK");
		}

		public void MsgBtnCLicked(object sender, EventArgs e){
			// Navigate to the Page.
			DisplayAlert("Followed", "You have successfully followed this guy!", "OK");
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
