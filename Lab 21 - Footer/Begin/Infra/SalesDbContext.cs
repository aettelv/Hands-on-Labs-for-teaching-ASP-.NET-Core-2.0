using Core;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>()
                .ToTable("Employees");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
