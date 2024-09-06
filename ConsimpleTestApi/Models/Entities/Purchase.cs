namespace ConsimpleTestApi.Models.Entities
{
    public class Purchase : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public int TotalCost { get; set; }

        public ICollection<ProductPurchase>? ProductPurchases { get; set; }

        public User? User { get; set; }
    }
}
