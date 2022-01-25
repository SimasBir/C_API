using _0124ShopAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }
        }
}
