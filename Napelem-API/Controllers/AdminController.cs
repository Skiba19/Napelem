using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        public JsonResult CreateEdit(Employee employee)
        {
           
            using (NapelemContext context = new NapelemContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            return new JsonResult(Ok(employee));
        }
    }
}
