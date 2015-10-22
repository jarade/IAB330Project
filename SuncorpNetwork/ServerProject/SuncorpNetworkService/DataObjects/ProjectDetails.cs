using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace SuncorpNetworkService.DataObjects
{
    public class ProjectDetails : EntityData
    {
        public int id {
            get; set;
        }
        public string FirstName {
            get; set;
        }
        public string LastName {
            get; set;
        }
        public string Title {
            get; set;
        }
        public string Location {
            get; set;
        }
        public string Information {
            get; set;
        }
        public string ExpertiseWanted {
            get; set;
        }
        public DateTime TimeStamp {
            get; set;
        }
        public string HasTags {
            get; set;
        }
    }
}