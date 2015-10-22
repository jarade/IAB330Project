using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

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
			await Navigation.PushModalAsync (new SideNavi ());
		}

		public void cancelBtnClicked(object sender, EventArgs e){
		}

		public async void registerBtnClicked(object sender, EventArgs e){
			await Navigation.PushModalAsync (new Registration ());
		}
	}
}

