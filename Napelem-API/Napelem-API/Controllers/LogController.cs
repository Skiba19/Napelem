using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpPost("AddLog")]
        public JsonResult AddLog(Log l)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Log log = new Log()
                {
                    projectID = l.projectID,
                    status=l.status,
                    timestamp=l.timestamp
                };
                context.Log.Add(log);
                context.SaveChanges();
            }
            return new JsonResult(Ok(l));
        }


    }
}
