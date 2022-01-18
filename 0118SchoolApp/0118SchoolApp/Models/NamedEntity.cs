using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Models
{
    public class NamedEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
