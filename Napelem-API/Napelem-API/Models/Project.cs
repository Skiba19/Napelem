using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Models
{
    public class Project
    {
        [Key]
        public int projectID { get; set; }
        public int employeeID { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public int project_price { get; set; }
        public string? project_location { get; set; }
        public string? project_description { get; set; }
        public string? project_orderer { get; set; }
        public int estimated_Time { get; set; }
        public int wage { get; set; }

    }
}
