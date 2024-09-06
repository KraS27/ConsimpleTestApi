using ConsimpleTestApi.Models.Enums;

namespace ConsimpleTestApi.Models.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Article {  get; set; } = null!;

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public ICollection<ProductPurchaseEntity>? ProductPurchases { get; set; }
    }
}
