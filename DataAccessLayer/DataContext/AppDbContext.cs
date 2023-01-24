using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>()
   .Property(p => p.EmployeeId).IsRequired(required: false);
            builder.Entity<EmployeeUpdate>()
.Property(p => p.ExternalId).IsRequired(required: false);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //builder.Entity<User>().ToTable("User");
        } 
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeUpdate> employeeUpdatedFile { get; set; }
        public DbSet<HierarchyItem>   HierarchyItems { get; set; }
        public DbSet<Position>   positions { get; set; }
    }
}
