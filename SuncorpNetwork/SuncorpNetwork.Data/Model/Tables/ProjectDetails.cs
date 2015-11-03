using System;
using SQLite;
using SQLite.Net.Attributes;

namespace SuncorpNetwork.Data
{
	public class ProjectDetails
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
		public string Information { get; set; }
		public string ExpertiseWanted { get; set; }
		public DateTime TimeStamp { get; set; }
		public string HasTags { get; set; }
		public string PosterEmail { get; set; }

		public ProjectDetails(){
		}

		public ProjectDetails(string firstName, string lastName){
			FirstName = firstName;
			LastName = lastName;
			Information = "";
			HasTags = "";
			TimeStamp = DateTime.Now;
		}

		public ProjectDetails(string firstName, string lastName, string title, string info, string exp){
			FirstName = firstName;
			LastName = lastName;
			Title = title;
			Information = info;
			HasTags = "";
			ExpertiseWanted = exp;
			TimeStamp = DateTime.Now;
		}

		public ProjectDetails(string firstName, string lastName, string title, string info, string exp, string tags, string email){
			FirstName = firstName;
			LastName = lastName;
			Title = title;
			Information = info;
			HasTags = tags;
			ExpertiseWanted = exp;
			TimeStamp = DateTime.UtcNow;
			PosterEmail = email;
		}

		public ProjectDetails(string firstName, string lastName, string info, DateTime date){
			FirstName = firstName;
			LastName = lastName;
			Information = info;
			HasTags = "";
			TimeStamp = date;
		}

		private string addTag(string tag){
			return HasTags += "|" + tag;
		}

		public void addTags(string[] tagArr){
			foreach (string tag in tagArr) {
				addTag (tag);
			}
		}

		public string[] convertStringToTagArray(){
			return HasTags.Split ('|');
		}

		public void clearTagsString(){
			HasTags = "";
		}
	}
}