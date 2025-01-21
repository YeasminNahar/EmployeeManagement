using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
