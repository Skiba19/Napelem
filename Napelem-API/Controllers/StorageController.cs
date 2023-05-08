using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    public class ComponentStorage
    {
        public Component Component { get; set; }
        public Storage Storage { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        //Add Component
        [HttpPost("AddComponentToStorage")]
        public JsonResult AddComponentToStorage(ComponentStorage componentStorage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Storage storage = new Storage
                {
                    componentID = componentStorage.Component.componentID,
                    row=componentStorage.Storage.row,
                    column=componentStorage.Storage.column,
                    level = componentStorage.Storage.level
                };
                
                context.Storages.Add(storage);
                context.SaveChanges();
            }
            return new JsonResult(Ok(componentStorage));
        }
    }
}
