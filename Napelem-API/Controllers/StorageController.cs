using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        //Add Component
        [HttpPost("AddComponentToStorage")]
        public JsonResult AddComponentToStorage(Component component, Storage storage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                storage.componentID=component.componentID;
                context.Components.Add(component);
                context.SaveChanges();
            }
            return new JsonResult(Ok(component));
        }
    }
}
