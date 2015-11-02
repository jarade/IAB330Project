using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using SuncorpNetwork.Data;

namespace SuncorpNetwork
{
	public partial class Login : BaseView
	{
		public Login ()
		{
			InitializeComponent ();
			base.Init ();
		}

		public async void loginBtnClicked(object sender, EventArgs e){
			var database = new PersonalDB ();
			//bool accepted = database.GetEmail (emailField.text);
			// if accepted {
			string email = emailField.Text;
			bool isEmail = database.IsEmail (email);
			//await DisplayAlert(email, isEmail.ToString(), "Done");
			if (isEmail) {
				await Navigation.PushModalAsync (new SideNavi (email));
			} else { 
				await DisplayAlert("Error", "Your email or password is not correct.", "Done"); 
			}
		}

		public void cancelBtnClicked(object sender, EventArgs e){
		}

		public async void registerBtnClicked(object sender, EventArgs e){
			await Navigation.PushModalAsync (new Registration ());
		}
	}
}

