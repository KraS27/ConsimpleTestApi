namespace ConsimpleTestApi.Models.DTO.Purchase
{
    public class CreatePurchaseRequest
    {
        public DateTime PurchaseDate { get; set; }

        public int TotalCost { get; set; }

        public ICollection<ProductsQuantityDTO> ProductsQuantity { get; set; } = new List<ProductsQuantityDTO>();

        public Guid UserId { get; set; }
    }
}
