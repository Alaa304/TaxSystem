using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable("EmployeeRoles");

            builder.HasKey(er => new { er.EmployeeID, er.RoleID });

            builder.HasOne(er => er.Employee)
                   .WithMany(e => e.EmployeeRoles)
                   .HasForeignKey(er => er.EmployeeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(er => er.Role)
                   .WithMany(r => r.EmployeeRoles)
                   .HasForeignKey(er => er.RoleID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
