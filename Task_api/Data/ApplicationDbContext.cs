using Microsoft.EntityFrameworkCore;
using Task_api.Models;

namespace Task_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-92KJCOU;Database=task;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
