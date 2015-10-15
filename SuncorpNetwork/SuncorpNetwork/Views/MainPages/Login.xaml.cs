using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Login : BaseView
	{
		public Login ()
		{
			InitializeComponent ();
			base.Init ();
		}

		public void loginBtnClicked(object sender, EventArgs e){
			Navigation.PushModalAsync (new SideNavi ());
		}

		public void registerBtnClicked(object sender, EventArgs e){
			Navigation.PushModalAsync (new Registration ());
		}
	}
}

