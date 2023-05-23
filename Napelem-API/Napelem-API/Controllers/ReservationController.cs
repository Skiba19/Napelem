using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napelem_API.Data;
using Napelem_API.Models;

namespace Napelem_API.Controllers
{
    public class ProjectComponent
    {
        public Project Project { get; set; }
        public Component Component { get; set; }
        public int qty { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        [HttpPost("AddReservation")]
        public JsonResult AddReservation(ProjectComponent projectComponent)
        {
            using (NapelemContext context = new NapelemContext())
            {
                Reservation reservation = new Reservation()
                {
                    projectID = projectComponent.Project.projectID,
                    componentID = projectComponent.Component.componentID,
                    reservationQuantity = projectComponent.qty
                };
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
            return new JsonResult(Ok(projectComponent));
        }
        [HttpGet("ListReservation")]
        public JsonResult ListReservation()
        {
            List<Reservation> reservation = new List<Reservation>();
            using (var context = new NapelemContext())
            {
                foreach (var r in context.Reservations)
                {
                    reservation.Add(r);
                }
            }
            return new JsonResult(Ok(reservation));
        }
    }
}
