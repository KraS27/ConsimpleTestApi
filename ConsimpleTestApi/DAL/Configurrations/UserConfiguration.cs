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

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Article)
                .HasColumnName("article")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(x => x.Category)
                .HasColumnName("category")
                .IsRequired();
        }
    }

    public class ProductPurchaseConfiguration : IEntityTypeConfiguration<ProductPurchase>
    {
        public void Configure(EntityTypeBuilder<ProductPurchase> builder)
        {
            builder.ToTable("productPurchase");

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(x => x.Purchase)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.PurchaseId);
        }
    }
}
