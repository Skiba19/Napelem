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
        
        [HttpPost("AddProject")]
        public JsonResult AddProject(Project project)
        {
            using (NapelemContext context = new NapelemContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
            return new JsonResult(Ok(project));
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
        //A7
        [HttpPost("ProjectClosure")]
        public JsonResult ProjectClosure(Project pro)
        {
            using (var db = new NapelemContext())
            {
                var project = db.Projects.Where(p => p.projectID == pro.projectID).FirstOrDefault();
                project.status=pro.status;
                db.SaveChanges();
            }
            return new JsonResult(Ok(pro));
        }
    }
}
