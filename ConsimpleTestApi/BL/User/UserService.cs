using ConsimpleTestApi.DAL;
using ConsimpleTestApi.Models.DTO.User;
using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ConsimpleTestApi.BL.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAsync(CreateUserRequest createUserRequest)
        {
            if (createUserRequest == null)
                throw new ArgumentNullException(nameof(createUserRequest));

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Patronymic = createUserRequest.Patronymic,
                BirthDate = createUserRequest.BirthDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"User {user.Id} register at {user.CreatedAt}");
        }

        public async Task<ICollection<UserBirthdayResponse>> GetUsersByBirthAsync(DateTime birthDate)
        {
            var response = await _context.Users
                .AsNoTracking()
                .Where(x => x.BirthDate == birthDate)
                .Select(x => new UserBirthdayResponse
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName} {x.Patronymic}"
                }).ToListAsync();

            return response;
        }
    }
}
