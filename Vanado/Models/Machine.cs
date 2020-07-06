using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vanado.Models
{
    public class Machine
    {
        [Key]
        public int Machine_id { get; set; }
        public string Machine_name { get; set; }

    }
}
