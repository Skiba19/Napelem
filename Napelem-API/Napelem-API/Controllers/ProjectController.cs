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
                project.project_price = 0;
                context.Projects.Add(project);
                context.SaveChanges();
            }
            return new JsonResult(Ok(project));
        }
        [HttpGet("ListProjects")]
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
        [HttpPost("ChangeStatus")]
        public JsonResult ProjectClosure(Project pro)
        {
            using (var db = new NapelemContext())
            {
                var project = db.Projects.Where(p => p.projectID == pro.projectID).FirstOrDefault();
                project.status = pro.status;
                db.SaveChanges();
            }
            return new JsonResult(Ok(pro));
        }
        [HttpPost("ChangePrice")]
        public JsonResult ChangePrice(Project pro)
        {
            using (var db = new NapelemContext())
            {
                var project = db.Projects.Where(p => p.projectID == pro.projectID).FirstOrDefault();
                project.project_price = pro.project_price;
                db.SaveChanges();
            }
            return new JsonResult(Ok(pro));
        }
        [HttpGet("GetProjectById")]
        public JsonResult GetProjectById(int projectID)
        {
            using (NapelemContext context = new NapelemContext())
            {
                foreach (Project p in context.Projects)
                {
                    if (p.projectID == projectID)
                    {
                        if (StatusCheck(p.projectID) == true)
                        {
                            return new JsonResult(p);
                        }
                    }
                }
                return null;
            }
        }  
        [HttpGet]
        public JsonResult ProjectByID(int projectID)
        {
            using (NapelemContext context = new NapelemContext())
            {
                foreach (Project p in context.Projects)
                {
                    if (p.projectID == projectID)
                    {
                            return new JsonResult(p);
                     
                    }
                }
                return null;
            }
        }
        
        private bool StatusCheck(int proId) 
        {
            using (NapelemContext db = new NapelemContext())
            {
                foreach (var p in db.Projects)
                {
                    if (p != null && p.status == "Scheduled" && p.projectID ==proId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
