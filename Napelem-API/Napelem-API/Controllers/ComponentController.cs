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
        public IActionResult AddComponent(Component component)
        {
            if (!IsComponentExistsByName(component))
            {
                using (NapelemContext context = new NapelemContext())
                {
                    context.Components.Add(component);
                    context.SaveChanges();
                }
                return new JsonResult(Ok(component));
            }
            return Conflict("Component already exists.");

        }

        private bool IsComponentExistsByName(Component comp)
        {
            using (var context = new NapelemContext())
            {
                foreach (var component in context.Components)
                {
                    if (component.name == comp.name)
                        return true;
                }
            }
            return false;
        }
        private bool IsComponentExistsByID(Component comp)
        {
            using (var context = new NapelemContext())
            {
                foreach (var component in context.Components)
                {
                    if (component.componentID == comp.componentID)
                        return true;
                }
            }
            return false;
        }
        //Change price
        [HttpPost("ChangePrice")]
        public IActionResult ChangePrice(Component comp)
        {
            if (IsComponentExistsByID(comp))
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
            return Conflict("Component does not exists.");

        }
        [HttpPost("ChangeMaxQuantity")]
        public IActionResult ChangeMaxQuantity(Component comp)
        {
            if (IsComponentExistsByID(comp))
            {
                int newMaxQuantity = (int)comp.max_quantity;
                using (var db = new NapelemContext())
                {
                    comp = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                    comp.max_quantity = newMaxQuantity;
                    db.SaveChanges();
                }
                return new JsonResult(Ok(comp));
            }
            return Conflict("Component does not exists.");

        }
        [HttpGet("SendComponent")]
        public JsonResult SendComponent()
        {
            List<Component> components = new List<Component>();
            using (var context = new NapelemContext())
            {
                foreach (var c in context.Components)
                {
                    components.Add(c);
                }
            }
            return new JsonResult(Ok(components));
        }
        [HttpPost("ChangeQuantity")]
        public IActionResult ChangeQuantity(Component comp)
        {
            if (IsComponentExistsByID(comp))
            {
                int newQuantity = (int)comp.quantity;
                using (var db = new NapelemContext())
                {
                    comp = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                    comp.quantity = newQuantity;
                    db.SaveChanges();
                }
                return new JsonResult(Ok(comp));
            }
            return Conflict("Component does not exists.");
        }
    }
}
