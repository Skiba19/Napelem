using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Models
{
    public class Reservation
    {
        [Key]
        public int reservationID { get; set; }
        public int projectID { get; set; }
        public int componentID { get; set; }
    }
}
