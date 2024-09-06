namespace ConsimpleTestApi.Models.DTO.Purchase
{
    public class CreatePurchaseRequest
    {
        public DateTime PurchaseDate { get; set; }

        public int TotalCost { get; set; }

        public ICollection<Guid> Products { get; set; } = new List<Guid>();

        public Guid UserId { get; set; }
    }
}
