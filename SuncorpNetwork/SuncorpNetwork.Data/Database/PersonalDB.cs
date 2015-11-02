using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace SuncorpNetwork.Data
{
	public class PersonalDB
	{

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="SuncorpNetwork.Data.PersonalDB"/> class.
		/// </summary>
		public PersonalDB ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();

			if(database.TableMappings.All(t => t.MappedType.Name != typeof(PersonalDetails).Name)){
				database.CreateTable<PersonalDetails> ();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public List<PersonalDetails> GetItems(){
			try{
				var items = database.Table<PersonalDetails> ().ToList<PersonalDetails> ();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<PersonalDetails>();
		}

		public bool IsEmail(string email){
			return 	database.Table<PersonalDetails> ().Where (
				x => x.Email == email).Any()
				? true : false;
		}

		/// <summary>
		/// Gets the personal details of the email.
		/// </summary>
		/// <returns>The details.</returns>
		/// <param name="email">Email.</param>
		public PersonalDetails GetDetails(string email){
			var item = database.Table<PersonalDetails> ().Where (
				x => x.Email == email
			           );
			Debug.WriteLine ("Item: " + (item.ToList().ElementAt(0)).ToString ());
			return (PersonalDetails)item.ToList().ElementAt(0);
		}

		/// <summary>
		/// Inserts the or update tag.
		/// </summary>
		/// <returns>The or update project.</returns>
		/// <param name="tag">Tag.</param>
		public int InsertOrUpdatePersonalDetails(PersonalDetails PD){
			return 	database.Table<PersonalDetails> ().Where (
				x => x.Email == PD.Email).Any()
				? database.Update (PD) : database.Insert (PD);
		}

		public void DeleteAllItems(){
			database.DeleteAll<PersonalDetails> ();
		}
	}
}

