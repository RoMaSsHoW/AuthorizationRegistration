namespace BLL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<string> LoginUserAsync(LoginDTO user);
        Task<bool> RegistreUserAsunc(RegisterDTO user);
    }
}
