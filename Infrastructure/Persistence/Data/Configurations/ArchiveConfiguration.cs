using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ArchiveConfiguration : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder.ToTable("Archives");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.EntityType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.ArchiveData)
                   .HasColumnType("nvarchar(max)");

            builder.Property(a => a.ArchiveDate)
                   .IsRequired();

            builder.Property(a => a.StoragePath)
                   .HasMaxLength(200);

            builder.HasOne(a => a.ArchivedByUser)
                   .WithMany(e => e.Archives)
                   .HasForeignKey(a => a.ArchivedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
