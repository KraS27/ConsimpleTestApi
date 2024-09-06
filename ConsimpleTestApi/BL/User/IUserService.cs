using ConsimpleTestApi.Models.DTO.User;

namespace ConsimpleTestApi.BL.User
{
    public interface IUserService
    {
        public Task Create(CreateUserRequest createUserRequest);

        public Task<ICollection<UserBirthdayResponse>> GetUsersByBirthDate(DateTime birthDate);
    }
}
