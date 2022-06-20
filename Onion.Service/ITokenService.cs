namespace Onion.Service;

public interface ITokenService
{
    TokenDto CreateAccessToken(User user);
}