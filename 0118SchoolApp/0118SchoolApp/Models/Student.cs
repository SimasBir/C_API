using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Models
{
    public class Student : NamedEntity
    {
        public string Gender { get; set; } // remake as schema M/F/NaN
        public int SchoolId { get; set; }
    }
}
