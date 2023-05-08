using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        //Add Component
        [HttpPost("AddProject")]
        public JsonResult AddProject(Project project, Employee employee)
        {
            using (NapelemContext context = new NapelemContext())
            {
                project.employeeID=employee.employeeID;
                context.Projects.Add(project);
                context.SaveChanges();
            }
            return new JsonResult(Ok(project));
        }
    }
}
