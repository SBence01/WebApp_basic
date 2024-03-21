using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
