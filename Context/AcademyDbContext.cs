using ConsoleApp20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Context
{
    internal class AcademyDbContext:DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=FI;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True ";
            optionsBuilder.UseSqlServer(connection);
        }

    }
}
