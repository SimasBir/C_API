using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Models
{
    public class Student : NamedEntity
    {
        public char Gender { get; set; } // remake as schema M/F/N(not available?)/U(unknown/unspecified?) - or tinyInt using ISO/IEC 5218?
        //[Compare("Gender")]
        //public char GenderSelection { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
