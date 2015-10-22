using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using SQLite.Net;

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
	}
}

