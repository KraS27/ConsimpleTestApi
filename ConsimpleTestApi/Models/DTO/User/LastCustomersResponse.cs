namespace ConsimpleTestApi.Models.DTO.User
{
    public class LastCustomersResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public DateTime LastPurchase {  get; set; }
    }
}
