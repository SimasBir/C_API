﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Dtos
{
    public class SchoolCreate
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
