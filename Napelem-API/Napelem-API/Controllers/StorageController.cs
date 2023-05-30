using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    public class ComponentStorage
    {
        public Component Component { get; set; }
        public Storage Storage { get; set; }
    }
    public class ReservationsAndProjectId
    {
        public List<Reservation> resers { get; set; }
        public int projectId { get; set; }
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
                    if (s.componentID == int.Parse(componentID))
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
                Component comp;
                Storage storage = new Storage
                {
                    componentID = componentStorage.Component.componentID,
                    row = componentStorage.Storage.row,
                    column = componentStorage.Storage.column,
                    level = componentStorage.Storage.level,
                    current_quantity = componentStorage.Storage.current_quantity
                };
                if (IsComponentFit(componentStorage))
                {
                    if (IsQuantityGreaterThenMax(componentStorage))
                    {
                        return Conflict("The quantity of the component dosen't fit in this storage!");
                    }
                    if (IsStorageExist(componentStorage))
                    {
                        Storage stor;
                        stor = context.Storages.Where(s => s.componentID == storage.componentID && s.column == storage.column && s.row == storage.row && s.level == storage.level).FirstOrDefault();
                        stor.current_quantity = stor.current_quantity + storage.current_quantity;
                        comp = context.Components.Where(c => c.componentID == storage.componentID).FirstOrDefault();
                        comp.quantity += storage.current_quantity;
                        context.SaveChanges();
                        return new JsonResult(Ok(componentStorage));
                    }
                    context.Storages.Add(storage);
                    comp = context.Components.Where(c => c.componentID == storage.componentID).FirstOrDefault();
                    comp.quantity += storage.current_quantity;
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
                            if (s.componentID != component.componentID)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool IsQuantityGreaterThenMax(ComponentStorage componentStorage)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Storage storage = componentStorage.Storage;
                Component comp = componentStorage.Component;
                Storage stor;
                stor = context.Storages.Where(s => s.componentID == comp.componentID && s.column == storage.column && s.row == storage.row && s.level == storage.level).FirstOrDefault();
                comp = context.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                if (stor == null)
                {
                    return false;
                }
                if (stor.current_quantity + storage.current_quantity > comp.max_quantity)
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
                    if (s.level == componentStorage.Storage.level && s.row == componentStorage.Storage.row
                        && s.column == componentStorage.Storage.column)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        [HttpGet("ListStorages")]
        public JsonResult ListStorages()
        {
            List<Storage> storages = new List<Storage>();
            using (var context = new NapelemContext())
            {
                foreach (var s in context.Storages)
                {
                    storages.Add(s);
                }
            }
            return new JsonResult(Ok(storages));
        }
        private bool IsComponentExistsByID(Storage stor)
        {
            using (var context = new NapelemContext())
            {
                foreach (var storage in context.Storages)
                {
                    if (storage.componentID == stor.componentID)
                        return true;
                }
            }
            return false;
        }
        [HttpPost("ChangeCurrent_quantity")]
        public IActionResult ChangeCurrent_quantity(Storage stor)
        {
            if (IsComponentExistsByID(stor))
            {
                using (var db = new NapelemContext())
                {
                    var storage = db.Storages.Where(s => s.storageID == stor.storageID).FirstOrDefault();
                    storage.current_quantity = stor.current_quantity;
                    db.SaveChanges();
                }
                return new JsonResult(Ok(stor));
            }
            return Conflict("Component does not exists.");
        }
        //ez lehet nem is kell
        /*private bool IsStorageComponentIdEqualsComponentID(int compId, Storage stor)
        {
            if(compId==stor.componentID)
            {
                return true;
            }
            return false;
        }*/
        private bool IsReservationProjectIdEqualProjectId(int proID, Reservation res)
        {
            using (var db = new NapelemContext())
            {
                if (res.projectID == proID)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsReservationComponentIdEqualComponentId(int compId, Reservation res)
        {
            using (var db = new NapelemContext())
            {
                if (res.componentID == compId)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPost("ChangeStorage")]
        public JsonResult ChangeStorage(ReservationsAndProjectId reservations)
        {
            
            using (var context = new NapelemContext())
            {
                
                foreach(var res in reservations.resers)
                {
                    var result = context.Components.Where(c => c.componentID == res.componentID).FirstOrDefault();
                    if (result != null)
                    {
                        if (res.componentID == result.componentID)
                        {
                            result.quantity -= res.reservationQuantity;
                        }
                    }
                    
                }
                context.SaveChanges();
                
            }
            

            for (int i = 0; i < reservations.resers.Count; i++)
            {
                using (var context = new NapelemContext())
                {
                    if (IsReservationProjectIdEqualProjectId(reservations.projectId, reservations.resers[i]) == true)
                    {
                        while (reservations.resers[i].reservationQuantity != 0)
                        {
                            foreach (var s in context.Storages)
                            {
                                if (IsReservationComponentIdEqualComponentId(s.componentID, reservations.resers[i]) == true)
                                {
                                    if (IsComponentExistsByID(s) == true && reservations.resers[i].componentID == s.componentID)
                                    {

                                        if (s.current_quantity - reservations.resers[i].reservationQuantity <= 0)
                                        {
                                            reservations.resers[i].reservationQuantity -= s.current_quantity;
                                            s.current_quantity -= s.current_quantity;
                                            //ChangeCurrent_quantity(s);//ha minden klappol itt ki kell törölni az adott sort
                                            context.Storages.Attach(s);
                                            context.Storages.Remove(s);
                                        }
                                        else
                                        {
                                            s.current_quantity -= reservations.resers[i].reservationQuantity;
                                            reservations.resers[i].reservationQuantity -= reservations.resers[i].reservationQuantity;
                                            ChangeCurrent_quantity(s);
                                        }
                                    }
                                    else
                                    {
                                        return new JsonResult(Conflict("There isnt a component like this"));
                                    }
                                }
                            }
                            
                            context.SaveChanges();
                        }
                        var reservation = context.Reservations.Where(r => r.reservationID == reservations.resers[i].reservationID).FirstOrDefault();
                        context.Reservations.Attach(reservation);
                        context.Reservations.Remove(reservation);
                        context.SaveChanges(); 

                    }
                }
            }
            return new JsonResult(Ok(reservations));
        }

    }
}
