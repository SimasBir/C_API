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
        public int GenderId { get; set; } // remake as schema M/F/N(not available?)/U(unknown/unspecified?) - or tinyInt using ISO/IEC 5218?
        public Gender Gender { get; set; } 
        //[Compare("Gender")]
        //public char GenderSelection { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
