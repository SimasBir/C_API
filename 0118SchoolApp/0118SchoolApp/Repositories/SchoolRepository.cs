using _0118SchoolApp.Data;
using _0118SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Repositories
{
    public class SchoolRepository : RepositoryBase<School>
    {
        public SchoolRepository(DataContext context) : base(context)
        {

        }
    }
}
