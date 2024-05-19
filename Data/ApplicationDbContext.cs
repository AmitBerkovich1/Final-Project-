using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext : DbContext
    {
       // public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<DangerLevel> dangerLevels { get; set; }
        public DbSet<Case> cases { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<LineOfBusiness> lineOfBusiness { get; set; }
        public DbSet<Company> company { get; set; }
    }
}
