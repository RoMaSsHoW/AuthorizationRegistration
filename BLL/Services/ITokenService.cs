namespace BLL.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(ClaimDTO userData);

        string GenerateRefreshToken();
    }
}
