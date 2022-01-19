using _0118SchoolApp.Data;
using _0118SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
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
        //public new School GetById(int id)
        //{
        //    return _context.Schools.Include(s => s.Students).FirstOrDefault(t => t.Id == id);
        //}
        //public new List<School> GetAll()
        //{
        //    List<School> schools = _context.Schools.Include(s => s.Students).ToList();
        //    return schools;
        //}
    }
}
