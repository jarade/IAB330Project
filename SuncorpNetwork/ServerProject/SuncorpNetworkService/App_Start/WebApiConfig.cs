using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using SuncorpNetworkService.DataObjects;
using SuncorpNetworkService.Models;

namespace SuncorpNetworkService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            // Set default and null value handling to "Include" for Json Serializer
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            
            Database.SetInitializer(new SuncorpNetworkInitializer());
        }
    }

    public class SuncorpNetworkInitializer : ClearDatabaseSchemaIfModelChanges<SuncorpNetworkContext>
    {
        protected override void Seed(SuncorpNetworkContext context)
        {
            List<ProjectDetails> projectDetails = new List<ProjectDetails>
            {
                new ProjectDetails { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName = "Last" },
                new ProjectDetails { Id = Guid.NewGuid().ToString(), FirstName = "Second item", LastName = "Last" },
            };

            foreach (ProjectDetails todoItem in projectDetails)
            {
                context.Set<ProjectDetails>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

