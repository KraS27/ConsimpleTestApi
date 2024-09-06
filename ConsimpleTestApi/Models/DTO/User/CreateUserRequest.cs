namespace ConsimpleTestApi.Models.DTO.User
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateTime BirthDate { get; set; }
    }
}
