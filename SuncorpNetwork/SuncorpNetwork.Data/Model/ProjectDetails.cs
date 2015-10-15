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
		public string Information { get; set; }
		public DateTime TimeStamp { get; set; }
		public string HasTags { get{ return HasTags;}set{ HasTags += value + "|";} }
			
		public ProjectDetails(){
		}

		public ProjectDetails(string firstName, string lastName, string[] hasTags){
			FirstName = firstName;
			LastName = lastName;
			HasTags = convertStringArraytoString(hasTags);
		}

		public void addInfo(string info){
			Information = info;
		}

		private string convertStringArraytoString(string[] hasTags){
			foreach (string tag in hasTags) {
				HasTags += tag;
			}

			return HasTags;
		}

		public string[] convertStringToTagArray(){
			return HasTags.Split ('|');
		}

		private void clearTagsString(){
			HasTags = "";
		}
	}
}