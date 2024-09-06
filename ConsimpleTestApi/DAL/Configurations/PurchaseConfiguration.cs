using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestApi.DAL.Configurrations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("purchases");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PurchaseDate)
                .HasColumnName("purchase_date")
                .IsRequired();

            builder.Property(x => x.TotalCost)
                 .HasColumnName("total_cost")
                 .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Purchases);
        }
    }
}
