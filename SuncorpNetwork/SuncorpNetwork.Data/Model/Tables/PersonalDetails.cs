using System;
using SQLite.Net.Attributes;

namespace SuncorpNetwork
{
	public class PersonalDetails
	{
		public string FirstName {	get;	set; }

		public string LastName {	get;	set; }

		[PrimaryKey]
		public string Email {	get;	set; }

		public string Pros {	get;	set; }

		public bool Availability {		get;	set; }

		public string Availability_2 {		get;	set; }

		public string ProfilePic {	get;	set; }

		public string Overview {	get;	set; } //self introduction


		public PersonalDetails ()
		{
			
		}

		public PersonalDetails ( string fn, string ln, string em)
		{
			FirstName = fn;
			LastName = ln;
			Email = em;
			Availability = true;
		}
	}
}

