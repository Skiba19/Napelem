using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    public class ProjectEmployee
    {
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        
        [HttpPost("AddProject")]
        public JsonResult AddProject(ProjectEmployee projectEmployee)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Project project = new Project()
                {
                    employeeID = projectEmployee.Employee.employeeID,
                    name = projectEmployee.Project.name,
                    status = projectEmployee.Project.name,
                    project_price = projectEmployee.Project.project_price,
                    project_location = projectEmployee.Project.project_location,
                    project_description = projectEmployee.Project.project_description,
                    project_orderer = projectEmployee.Project.project_orderer,
                    estimated_Time = projectEmployee.Project.estimated_Time,
                    wage = projectEmployee.Project.wage
                };
                context.Projects.Add(project);
                context.SaveChanges();
            }
            return new JsonResult(Ok(projectEmployee));
        }
    }
}
