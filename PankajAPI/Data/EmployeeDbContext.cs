using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PankajAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PankajAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    DOB = DateTime.Parse("22-june-2023"),
                    Name = "Shakespeare"
                },
                 new Employee
                 {
                     Id = 2,
                     DOB = DateTime.Parse("23-june-2023"),
                     Name = "Jhon"
                 },
                  new Employee
                  {
                      Id = 3,
                      DOB = DateTime.Parse("24-june-2023"),
                      Name = "Keets"
                  },
                   new Employee
                   {
                       Id = 4,
                       DOB = DateTime.Parse("25-june-2023"),
                       Name = "Aristotle"
                   },
                    new Employee
                    {
                        Id = 5,
                        DOB = DateTime.Parse("26-june-2023"),
                        Name = "Chanakya"
                    },
                     new Employee
                     {
                         Id = 6,
                         DOB = DateTime.Parse("27-june-2023"),
                         Name = "Balmiki"
                     }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }

    /*
    public class YourDbContextFactory : IDesignTimeDbContextFactory<EmployeeDbContext>
    {
        public EmployeeDbContext CreateDbContext(string[] args)
        {
            var connectionString = "server=localhost;user=root;database=db;password=a#67ja5Jjj";
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new EmployeeDbContext(optionsBuilder.Options);
        }
    }*/
}
