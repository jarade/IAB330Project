using System;
using SuncorpNetwork.Data;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuncorpNetwork
{
	public partial class Registration : BaseView
	{
		public Registration ()
		{
			InitializeComponent ();
		}

		public async void SubmitReg (object sender, EventArgs e)
		{
			string fn = entryFirstName.Text;
			string ln = entryLastName.Text;
			string em = entryEmail.Text;
			string pw = "password";

			if (fn != "") {
				if (ln != "") {
					if (em != "") {
						PersonalDetails pd = new PersonalDetails (fn,ln,em);
						var database = new PersonalDB ();
						database.InsertOrUpdatePersonalDetails (pd);
						PersonalDetails item = database.GetDetails(em);
						AddRegistration (em, pw);

						// navigate here
						((App)Application.Current).UserEmail = em;
						await Navigation.PushModalAsync (new SideNavi ());
					}
				}
			}
		}

		public async void AddRegistration(string email, string password){
			var database = new LoginTable ();
			LoginDetails details = new LoginDetails (email, password);
			database.InsertOrUpdate (details);

			//await DisplayAlert ("Alert", "Registered Successfully: " + database.GetItems().Count.ToString(), "OK");
		}
	}
}

