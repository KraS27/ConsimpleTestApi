using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestApi.DAL.Configurrations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired();

            builder.Property(x => x.Patronymic)
                .HasColumnName("patronymic")
                .IsRequired();

            builder.Property(x => x.BirthDate)
               .HasColumnName("birth_date")
               .IsRequired();

            builder.HasMany(u => u.Purchases)
                .WithOne(p => p.User);
        }
    }
}
