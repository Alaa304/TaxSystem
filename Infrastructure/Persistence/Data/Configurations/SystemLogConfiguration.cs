using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SystemLogConfiguration : IEntityTypeConfiguration<SystemLog>
    {
        public void Configure(EntityTypeBuilder<SystemLog> builder)
        {
            builder.ToTable("SystemLogs");

            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.TableName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(sl => sl.ActionType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(sl => sl.Changes)
                   .HasColumnType("nvarchar(max)");

            builder.Property(sl => sl.ActionDate)
                   .IsRequired();

            builder.HasOne(sl => sl.Employee)
                   .WithMany(e => e.SystemLogs)
                   .HasForeignKey(sl => sl.EmployeeID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
