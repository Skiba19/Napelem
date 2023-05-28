using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Models
{
    public class Component
    {
        [Key]
        public int componentID { get; set; }
        public string? name { get; set; }
        public int? max_quantity { get; set; }
        public int? price { get; set; }
    }
}
