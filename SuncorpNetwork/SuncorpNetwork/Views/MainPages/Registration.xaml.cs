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
			if (fn != "") {
				if (ln != "") {
					if (em != "") {
						PersonalDetails pd = new PersonalDetails (fn,ln,em);
						var database = new PersonalDB ();
						database.InsertOrUpdatePersonalDetails (pd);
						PersonalDetails item = database.GetDetails(em);
						await DisplayAlert ("Alert", "Registered Successfully: " + item.Email, "OK");




					}
				}
			}
		}
	}
}

