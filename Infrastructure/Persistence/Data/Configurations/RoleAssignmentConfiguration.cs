using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class RoleAssignmentConfiguration : IEntityTypeConfiguration<RoleAssignment>
    {
        public void Configure(EntityTypeBuilder<RoleAssignment> builder)
        {
            builder.ToTable("RoleAssignments");

            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Person)
                .WithMany(p => p.RoleAssignments)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Unit)
                .WithMany(u => u.RoleAssignments)
                .HasForeignKey(r => r.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.RoleType)
                .IsRequired();

            builder.Property(r => r.StartDate)
                .IsRequired();
        }
    }
}
