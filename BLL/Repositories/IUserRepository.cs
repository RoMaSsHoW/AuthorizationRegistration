namespace BLL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<bool> LoginUserAsync(LoginDTO user);
        Task<bool> RegistreUserAsunc(RegisterDTO user);
    }
}
