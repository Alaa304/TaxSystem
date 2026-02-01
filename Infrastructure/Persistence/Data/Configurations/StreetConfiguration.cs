using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable("Streets");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.StreetName)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(s => s.Shaikha)
                .WithMany(sh => sh.Streets)
                .HasForeignKey(s => s.ShaikhaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
