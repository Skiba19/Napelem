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
        
        [HttpPost("AddReservation")]
        public JsonResult AddReservation(ProjectEmployee projectEmployee)
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
        [HttpPost("ListProjects")]
        public JsonResult ListProjects() 
        {
            List<Project> projects = new List<Project>();
            using (var context = new NapelemContext())
            {
                foreach (var p in context.Projects)
                {
                    projects.Add(p);
                }
            }
            return new JsonResult(Ok(projects));
        }
        [HttpPost("SetTimeAndWage")]
        public JsonResult SetTimeAndWage(Project pro)
        {
            using (var db = new NapelemContext())
            {
                var project = db.Projects.Where(p => p.projectID == pro.projectID).FirstOrDefault();
                project.estimated_Time = pro.estimated_Time;
                project.wage = pro.wage;
                db.SaveChanges();
            }
                return new JsonResult(Ok(pro));
        }
    }
}
