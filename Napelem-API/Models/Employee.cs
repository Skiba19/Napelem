using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        public string? name { get; set; }
        public string? role { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
