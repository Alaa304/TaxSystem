using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.NationalID)
                .IsRequired()
                .HasMaxLength(14);

            builder.HasIndex(p => p.NationalID)
                .IsUnique();

            builder.Property(p => p.Phone)
                .HasMaxLength(20);

            builder.Property(p => p.Address)
                .HasMaxLength(300);

            builder.Property(p => p.PersonType)
                .IsRequired();
        }
    }
}
