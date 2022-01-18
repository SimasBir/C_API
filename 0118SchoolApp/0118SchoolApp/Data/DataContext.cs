using _0118SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
