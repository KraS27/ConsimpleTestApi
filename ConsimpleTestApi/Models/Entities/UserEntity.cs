namespace ConsimpleTestApi.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public ICollection<PurchaseEntity>? Purchases {  get; set; } 
    }
}
