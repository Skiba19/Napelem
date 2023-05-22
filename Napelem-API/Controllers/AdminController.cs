using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;
using System.Net;



namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateEdit(Employee employee)
        {
            if (!IsUserExists(employee))
            {
                using (NapelemContext context = new NapelemContext())
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                return new JsonResult(Ok(employee));
            }
            return Conflict("User already exists.");

        }

        private bool IsUserExists(Employee emp) {

            using (var context = new NapelemContext())
            {
                foreach (var employee in context.Employees)
                {
                    if (employee.name == emp.name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
