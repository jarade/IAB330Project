using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace SuncorpNetwork
{
	public partial class Forum1 : BaseView
	{

		Forum1ContentViewModel f1vm;
		public Forum1 ()
		{
			f1vm = new Forum1ContentViewModel ();
			BindingContext = f1vm;
			InitializeComponent ();
		}

		public void OnItemTapped(object o, ItemTappedEventArgs e){
			var local_fpost = e.Item as Forum1Post;
			if (e != null) {
				switchPage(new Forum1Content(local_fpost as Forum1Post));
			}
		}



		public async void navigateToTemporaryPage(StackLayout stack){
			// Create the temporary page
			await Navigation.PushModalAsync (new BaseView {
				Padding = new Thickness(15,5,15,5),
				BackgroundColor = Color.FromHex("#0DA195"),
				Content = stack
			});
		}

		public void CreatepostCicked(object sender, EventArgs e){
			// Navigate to the Page.
			switchPage(new Forum1CreatePost ());
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

