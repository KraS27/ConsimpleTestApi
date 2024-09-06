using ConsimpleTestApi.Models.DTO.User;

namespace ConsimpleTestApi.BL.User
{
    public interface IUserService
    {
        public Task CreateAsync(CreateUserRequest createUserRequest);

        public Task<ICollection<UserBirthdayResponse>> GetUsersByBirthAsync(DateTime birthDate);

        public Task<ICollection<LastCustomersResponse>> GetRecentCustomersAsync(int days);

        public Task<ICollection<PopularCatagoryResponse>> GetPopularCatagoryAsync(Guid customerId);
    }
}
