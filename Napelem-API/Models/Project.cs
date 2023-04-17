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

    }
}
