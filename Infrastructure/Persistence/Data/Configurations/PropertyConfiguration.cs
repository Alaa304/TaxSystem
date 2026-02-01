using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CurrentPropertyNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.OldPropertyNo)
                .HasMaxLength(50);

            builder.Property(p => p.PlanningNo)
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.BuildYear)
                .IsRequired();

            builder.HasOne(p => p.Street)
                .WithMany(s => s.Properties)
                .HasForeignKey(p => p.StreetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
