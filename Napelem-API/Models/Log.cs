using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Models
{
    public class Log
    {
        [Key]
        public int logID { get; set; }
        public int projectID { get; set; }
        public string? status { get; set; }
        public string? timestamp { get; set; }
    }
}
