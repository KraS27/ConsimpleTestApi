using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsimpleTestApi.DAL.Configurrations
{
    public class ProductPurchaseConfiguration : IEntityTypeConfiguration<ProductPurchase>
    {
        public void Configure(EntityTypeBuilder<ProductPurchase> builder)
        {
            builder.ToTable("productPurchase");

            builder.HasKey(x => new { x.ProductId, x.PurchaseId });

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(x => x.Purchase)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.PurchaseId);
        }
    }
}
