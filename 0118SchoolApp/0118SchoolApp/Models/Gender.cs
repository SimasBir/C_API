using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Models
{
    public class Gender : NamedEntity
    {
        public List<Student> Students { get; set; }
    }
}
