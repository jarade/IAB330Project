using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using SQLite.Net;
using System.Diagnostics;

namespace SuncorpNetwork.Data
{
	public class ProjectDetailsDatabase
	{
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="SuncorpNetwork.Data.ProjectDetialsDatabase"/> class.
		/// </summary>
		public ProjectDetailsDatabase (){
			database = DependencyService.Get<ISqlite> ().GetConnection ();

			if(database.TableMappings.All(t => t.MappedType.Name != typeof(ProjectDetails).Name)){
				database.CreateTable<ProjectDetails> ();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		public List<ProjectDetails> GetItems(){
			var items = database.Table<ProjectDetails> ().ToList<ProjectDetails> ();
		
			return items;
		}

		public List<ProjectDetails> GetItemsWithTags(List<string> tags){
			try{
				var items = database.Table<ProjectDetails> ().ToList<ProjectDetails> ();
				List<ProjectDetails> results = new List<ProjectDetails> ();

				foreach (ProjectDetails item in items) {
					
					string allTags = item.HasTags;
					string[] allTagsSep = allTags.Split ('|');

					foreach (string tag in allTagsSep) {
						if(tags.Contains(tag)){
							if(!results.Contains(item)){
								results.Add (item);
							}
						}
					}
				}
				return results;

			}catch(Exception e){
				Debug.WriteLine("Exception: " + e);
			}
			return new List<ProjectDetails>();
		}

		/// <summary>
		/// Inserts the or update project.
		/// </summary>
		/// <returns>The or update project.</returns>
		/// <param name="project">Project.</param>
		public int InsertOrUpdateProject(ProjectDetails project){
			return 	database.Table<ProjectDetails> ().Where (
						x => x.id == project.id).Any ()
					? database.Update (project) : database.Insert (project);
		}

		public void DeleteAllItems(){
			database.DeleteAll<ProjectDetails> ();
		}
	}
}

