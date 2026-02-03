using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Presistence.Data
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options) { }

    // DbSets

        // phase 1
        public DbSet<Person> Persons { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<Shaikha> Shaikhas { get; set; }
        public DbSet<Street> Streets { get; set; }

        // phase 2
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Archive> Archives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all entity configurations from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
