namespace BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext dbContext, IMapper mapper, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users
                .OrderByDescending(u => u.UserLastLoginTime)
                .ToListAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<string> LoginUserAsync(LoginDTO user)
        {
            var userFromDB = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserEmail == user.Email);
            if (userFromDB != null && BCrypt.Net.BCrypt.Verify(user.Password, userFromDB.UserPasswordHash))
            {
                userFromDB.UserLastLoginTime = DateTime.Now;
                await _dbContext.SaveChangesAsync();

                var claim = new ClaimDTO()
                {
                    Id = userFromDB.UserId,
                    Name = userFromDB.UserName,
                    Email = userFromDB.UserEmail
                };

                var token = _tokenService.GenerateAccessToken(claim);

                return token;
            }
            return string.Empty;
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
