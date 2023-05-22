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
                }
                return null;
            }
            
        }
    }
}
