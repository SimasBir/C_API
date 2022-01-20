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
        public DbSet<Gender> Genders { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Gender>().HasData(
                new Gender()
                {
                    Id = 1,
                    Name = "Male",
                },
                new Gender()
                {
                    Id = 2,
                    Name = "Female",
                },
                new Gender()
                {
                    Id = 3,
                    Name = "Unspecified",
                }
            );
        }
    }
}
