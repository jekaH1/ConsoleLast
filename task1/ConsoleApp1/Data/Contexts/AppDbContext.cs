using ConsoleApp1.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Contexts
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2561JS6\\SQLEXPRESS;Database=UserDb122;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }

    }
}
