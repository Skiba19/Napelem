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

        [HttpGet("GetStorage")]
        public JsonResult Get(string componentID)
        {
            using (NapelemContext context = new NapelemContext())
            {



                //Login button
                foreach (Storage s in context.Storages)
                {
                    if (s.componentID == int.Parse(componentID) )
                    {
                        return new JsonResult(s);
                    }
                    //ehelyett kell elküldeni az "Acess Denied"-t
                }
                return null;
            }
        }
        //Add Component
        [HttpPost("AddComponentToStorage")]
        public IActionResult AddComponentToStorage(ComponentStorage componentStorage)
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
                if (IsComponentFit(componentStorage))
                {
                    if (IsQuantityGreaterThenMax(componentStorage))
                    {
                        return Conflict("The quantity of the component dosen't fit in this storage!");
                    }
                    if(IsStorageExist(componentStorage))
                    {
                        Storage stor;
                        stor = context.Storages.Where(s => s.componentID == storage.componentID).FirstOrDefault();
                        stor.quantity = stor.quantity+storage.quantity;
                        context.SaveChanges();
                    }
                    context.Storages.Add(storage);
                    context.SaveChanges();
                    var comp = context.Components.Where(c => c.componentID == componentStorage.Component.componentID).FirstOrDefault();
                    comp.quantity = componentStorage.Component.quantity;
                    context.SaveChanges();
                    return new JsonResult(Ok(componentStorage));

                }
                
            }
            return Conflict("There is already another compononent in this storage!");


        }
        private bool IsComponentFit(ComponentStorage componentStorage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Storage storage = componentStorage.Storage;
                Component component = componentStorage.Component;
                bool isTableEmpty = !context.Storages.Any();

                if (isTableEmpty)
                {
                    return true;
                }
                else
                {
                    foreach (Storage s in context.Storages)
                    {
                        if (s.level == storage.level && s.row == storage.row && s.column == storage.column)
                        {
                            if (s.componentID == null || s.componentID == component.componentID)
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
        }

        private bool IsQuantityGreaterThenMax(ComponentStorage componentStorage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Storage storage = componentStorage.Storage;
                Component component = componentStorage.Component;
                Storage stor;
                stor = context.Storages.Where(s => s.componentID == component.componentID).FirstOrDefault();                
                if(stor.quantity+component.quantity > component.max_quantity)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsStorageExist(ComponentStorage componentStorage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                foreach (Storage s in context.Storages)
                {
                    if(s.level==componentStorage.Storage.level && s.row == componentStorage.Storage.row
                        && s.column == componentStorage.Storage.column)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
