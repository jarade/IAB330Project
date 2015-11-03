using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using SQLite.Net;
using System.Linq;

namespace SuncorpNetwork.Data
{
	public class NotificationsTable
	{	
		SQLiteConnection database;

		public NotificationsTable (){
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			//database.DropTable<Notification> ();
			if(database.TableMappings.All(t => t.MappedType.Name != typeof(Notification).Name)){
				database.CreateTable<Notification> ();
				database.Commit ();
			}
		}

		public List<Notification> GetItems(){
			try{
				var items = database.Table<Notification> ().ToList<Notification> ();
				//Debug.WriteLine ("Items: " + items.ToString() + " " + items.Count.ToString());
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<Notification>();
		}

		public List<Notification> GetItemsWithout(string email){
			try{
				var items = database.Table<Notification> ().Where(
					x => x.PosterEmail != email
				).ToList();
				return items;
			}catch(Exception e){
				Debug.WriteLine ("Error: " + e.ToString());
			}
			return new List<Notification>();
		}

		public int InsertOrUpdate(Notification notification){
			try{
				return 	database.Table<Notification> ().Where (
					x => x.CompositePrimaryKey == notification.CompositePrimaryKey).Any()
					? database.Update (notification) : database.Insert (notification);
			}catch(Exception e){
				Debug.WriteLine ("Exception: " + e.ToString());
			}

			return 0;
		}

		public void DeleteAllItems(){
			database.DeleteAll<Notification> ();
		}
	}
}

