namespace ConsimpleTestApi.Models.Entities
{
    public class PurchaseEntity : BaseEntity
    {
        public DateTime Date { get; set; }

        public int TotalCost { get; set; }

        public ICollection<ProductPurchaseEntity>? ProductPurchases { get; set; }

        public UserEntity? User { get; set; }
    }
}
