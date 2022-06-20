namespace Onion.Api.Contollers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : CustomBaseController
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

        
    [HttpPost]
    public async Task<IActionResult> CreateAccessToken(UserDto userDto)
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateRefreshToken(UserDto userDto)

    {

    }
}

