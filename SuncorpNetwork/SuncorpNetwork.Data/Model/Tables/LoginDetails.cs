using System;
using SQLite.Net.Attributes;

namespace SuncorpNetwork.Data
{
	public class LoginDetails
	{
		[PrimaryKey]
		public string Email { get; set; }
		private string Password { get; set; }

		public LoginDetails ()
		{
		}

		public LoginDetails(string email, string password){
			Email = email;
			Password = password;
		}
	}
}

