using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        //Add Component
        [HttpPost("AddComponent")]
        public JsonResult AddComponent(Component component)
        {

            using (NapelemContext context = new NapelemContext())
            {
                context.Components.Add(component);
                context.SaveChanges();
            }
            return new JsonResult(Ok(component));
        }
        //Change price
        [HttpPost("ChangePrice")]
        public JsonResult ChangePrice(Component comp)
        {
            int newPrice = (int)comp.price;
            using (var db = new NapelemContext())
            {
                comp = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                comp.price = newPrice;
                db.SaveChanges();
            }
            return new JsonResult(Ok(comp));
        }
        [HttpPost("ChangeMaxQuantity")]
        public JsonResult ChangeMaxQuantity(Component comp)
        {
            int newMaxQuantity = (int)comp.max_quantity;
            using (var db = new NapelemContext())
            {
                comp = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                comp.price = newMaxQuantity;
                db.SaveChanges();
            }
            return new JsonResult(Ok(comp));
        }

    }
}
