using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ShaikhaConfiguration : IEntityTypeConfiguration<Shaikha>
    {
        public void Configure(EntityTypeBuilder<Shaikha> builder)
        {
            builder.ToTable("Shaikhas");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.ShaikhaName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Governorate)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
