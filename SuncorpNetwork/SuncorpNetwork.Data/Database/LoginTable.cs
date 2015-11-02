using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;

namespace SuncorpNetwork.Data
{
	public class LoginTable
	{
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="SuncorpNetwork.Data.ProjectDetialsDatabase"/> class.
		/// </summary>
		public LoginTable (){
			database = DependencyService.Get<ISqlite> ().GetConnection ();

			if(database.TableMappings.All(t => t.MappedType.Name != typeof(LoginDetails).Name)){
				database.CreateTable<LoginDetails> ();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public List<LoginDetails> GetItems(){
			
			try{
				var items = database.Table<LoginDetails> ().ToList<LoginDetails> ();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<LoginDetails>();
		}

		public int InsertOrUpdate(LoginDetails details){
			return 	database.Table<LoginDetails> ().Where (
				x => x.Email == details.Email).Any ()
				? database.Update (details) : database.Insert (details);
		}

		public void DeleteAllItems(){
			database.DeleteAll<LoginDetails> ();
		}
	}
}