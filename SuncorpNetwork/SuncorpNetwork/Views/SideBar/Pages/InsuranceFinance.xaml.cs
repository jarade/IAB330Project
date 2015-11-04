using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class InsuranceFinance : ContentPage{

		public InsuranceFinance ()
		{
			InitializeComponent ();			

			StackLayout layout = new StackLayout(){
				Spacing = 20,
				Padding = 20,
			};

			var photo = new RoundedBoxView(){
				WidthRequest = 100,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
			};
			photo.Source = ImageSource.FromFile("images.jpg");
			layout.Children.Add(photo);
			this.Content = layout;
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

