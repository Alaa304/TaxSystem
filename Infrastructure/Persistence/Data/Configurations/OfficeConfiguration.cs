using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Governorate)
                .HasMaxLength(50);

            builder.Property(o => o.City)
                .HasMaxLength(50);

            builder.Property(o => o.OfficeName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.OfficeCode)
                .HasMaxLength(20);
        }
    }
}
