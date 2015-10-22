using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using SuncorpNetworkService.DataObjects;
using SuncorpNetworkService.Models;

namespace SuncorpNetworkService.Controllers
{
    public class ProjectDetailController : TableController<ProjectDetails>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SuncorpNetworkContext context = new SuncorpNetworkContext();
            DomainManager = new EntityDomainManager<ProjectDetails>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<ProjectDetails> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ProjectDetails> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ProjectDetails> PatchTodoItem(string id, Delta<ProjectDetails> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(ProjectDetails item)
        {
            ProjectDetails current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}