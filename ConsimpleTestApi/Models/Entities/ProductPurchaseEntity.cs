namespace ConsimpleTestApi.Models.Entities
{
    public class ProductPurchaseEntity
    {
        public Guid PurchaseId { get; set; }
        public PurchaseEntity? Purchase { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
