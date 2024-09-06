namespace ConsimpleTestApi.Models.Entities
{
    public class ProductPurchase
    {
        public Guid PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
