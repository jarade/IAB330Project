using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using SQLite.Net;
using System.Diagnostics;

namespace SuncorpNetwork.Data
{
	public class TagDatabase
	{
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="SuncorpNetwork.Data.ProjectDetialsDatabase"/> class.
		/// </summary>
		public TagDatabase (){
			database = DependencyService.Get<ISqlite> ().GetConnection ();

			if(database.TableMappings.All(t => t.MappedType.Name != typeof(Tag).Name)){
				database.CreateTable<Tag> ();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public List<Tag> GetItems(){
	
			Debug.WriteLine ("Get Item Start");
			try{
				var items = database.Table<Tag> ().ToList<Tag> ();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<Tag>();
		}

		/// <summary>
		/// Inserts the or update tag.
		/// </summary>
		/// <returns>The or update project.</returns>
		/// <param name="tag">Tag.</param>
		public int InsertOrUpdateTag(Tag tag){
			return 	database.Table<Tag> ().Where (
				x => x.TagName == tag.TagName).Any ()
				? database.Update (tag) : database.Insert (tag);
		}

		public void DeleteAllItems(){
			database.DeleteAll<Tag> ();
		}
	}
}

