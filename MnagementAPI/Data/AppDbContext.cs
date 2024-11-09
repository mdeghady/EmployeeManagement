using Microsoft.EntityFrameworkCore;
using MnagementAPI.Models;

namespace MnagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<JobRole> JobRoles => Set<JobRole>();
    }
}
