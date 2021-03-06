﻿using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace SuncorpNetwork.Data
{
	public class Forum1DB
	{

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="SuncorpNetwork.Data.PersonalDB"/> class.
		/// </summary>
		public Forum1DB ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();

			if(database.TableMappings.All(t => t.MappedType.Name != typeof(Forum1Post).Name)){
				database.CreateTable<Forum1Post> ();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public List<Forum1Post> GetItems(){
			try{
				var items = database.Table<Forum1Post> ().ToList<Forum1Post> ();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<Forum1Post>();
		}

		public int InsertNewPost(Forum1Post forum1post){
			return 	database.Table<Forum1Post> ().Where (
				x => x.ID == forum1post.ID).Any()
				? database.Update (forum1post) : database.Insert (forum1post);
		}

		public PersonalDetails GetDetails(string email){
			var item = database.Table<PersonalDetails> ().Where (
				x => x.Email == email
			);
			return (PersonalDetails)item.ToList().ElementAt(0);
		}


			
		}
	}


