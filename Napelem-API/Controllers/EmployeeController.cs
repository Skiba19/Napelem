using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController() { }

        // Create/Edit
        [HttpGet]
        public JsonResult Get(string username, string password)
        {
            using (NapelemContext context = new NapelemContext())
            {

                

                //Login button
                foreach (Employee e in context.Employees)
                {
                    if (e.username == username && e.password == password)
                    {
                        return new JsonResult(e);
                    }
                    //ehelyett kell elküldeni az "Acess Denied"-t
                }
                return null;
                /*
                //Send Componens
                foreach (Component c in context.Components)
                {
                    Console.WriteLine(c.componentID.ToString(), c.name, c.quantity, c.max_quantity, c.price);
                    //itt el kell küldeni ezeket az adatokat
                }
                //Add new item button
                {
                    string name = "test";//egyenlővé kell tenni a kapott értékkel
                    int price = 0, maxQuantity = 0;//ugyszintén (csak a maxQuantityt)
                    Component item = new Component()
                    {
                        name = name,
                        price = price,
                        quantity = 0,
                        max_quantity = maxQuantity
                    };
                    context.Components.Add(item);
                    context.SaveChanges();
                }
                //Change price
                {
                    int id = 1, newPrice = 600;//itt kapja meg az id-t és az új árat
                    using (var db = new NapelemContext())
                    {
                        var component = db.Components.Where(c => c.componentID == id).FirstOrDefault();
                        component.price = newPrice;
                        db.SaveChanges();
                    }
                }*/

            }
            
        }
    }
}
