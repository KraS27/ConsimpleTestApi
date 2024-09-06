using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestApi.DAL.Configurrations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            builder.ToTable("purchases");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
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
