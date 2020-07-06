using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vanado.Models
{
    public class Failure
    {
        public int Failure_id { get; set; }
        public string Failure_name { get; set; }
        public string Failure_description { get; set; }
        public DateTime Failure_datetime { get; set; }
        public int Failure_machineid { get; set; }
        public bool Failure_status { get; set; }
        public string Failure_documentation { get; set; }
        public int Failure_priority { get; set; }

    }
}
