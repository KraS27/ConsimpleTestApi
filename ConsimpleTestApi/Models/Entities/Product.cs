using ConsimpleTestApi.Models.Enums;

namespace ConsimpleTestApi.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Article {  get; set; } = null!;

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public ICollection<ProductPurchase>? ProductPurchases { get; set; }
    }
}
