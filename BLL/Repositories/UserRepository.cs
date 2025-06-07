
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users
                .OrderByDescending(u => u.UserLastLoginTime)
                .ToListAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public Task<bool> LoginUserAsync(LoginDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistreUserAsunc(RegisterDTO user)
        {
            try
            {
                var passworHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var newUser = new User
                {
                    UserName = user.Name,
                    UserEmail = user.Email,
                    UserPasswordHash = passworHash,
                    UserRegistrationTime = DateTime.Now,
                    RefreshToken = user.RefreshToken
                };

                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("unique") ?? false)
            {
                return false;
            }
        }
    }
}
