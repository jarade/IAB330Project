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

		public PersonalDetails GetDetails(string email){
			var item = database.Table<PersonalDetails> ().Where (
				x => x.Email == email
			           );
			return (PersonalDetails)item.ToList().ElementAt(0);
		}
			
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

