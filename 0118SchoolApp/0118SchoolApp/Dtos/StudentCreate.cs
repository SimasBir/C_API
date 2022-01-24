using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Dtos
{
    public class StudentCreate
    {
        [Required]
        [StringLength(255, MinimumLength = 3)] //[MinLength(3)] irgi tinka, nes APIController pats pagauna ModelState.IsValid
        public string Name { get; set; }
        public int GenderId { get; set; } 
        public int SchoolId { get; set; }
    }
}
