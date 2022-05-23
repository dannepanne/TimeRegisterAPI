using Microsoft.EntityFrameworkCore;

namespace TimeRegisterAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TimeReport> TimeReports { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        
    }
}
