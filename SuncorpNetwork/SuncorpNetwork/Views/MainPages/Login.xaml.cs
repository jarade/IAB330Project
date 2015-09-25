using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		public void loginBtnClicked(object sender, EventArgs e){
			this.Navigation.PushModalAsync (new SideNavi ());
		}
	}
}

