using Microsoft.Extensions.Options;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly JWTSettings _jwtSettings;

        public AuthController(
            IOptions<JWTSettings> jwtSettings,
            ITokenService tokenService)
        {
            _tokenService = tokenService;
            _jwtSettings = jwtSettings.Value;
        }
    }
}
