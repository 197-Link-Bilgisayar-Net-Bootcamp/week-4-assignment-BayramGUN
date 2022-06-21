using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Onion.Service;

public class TokenService
{
    public IConfiguration Configuration { get; set; }
    public TokenService(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public Token CreateAccessToken(User user)
    {
        TokenDto tokenDto = new TokenDto();

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenOptions:SecurityKey"]));

        SigningCredentials credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        tokenDto.Expiration = DateTime.Now.AddMinutes(20);
        JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer:Configuration["TokenOptions:Issuer"],
            audience:Configuration["TokenOptions:Audience"],
            expires:tokenDto.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: credintials
        );
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //Token is existed
        tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
        tokenModel.RefreshToken = CreateRefreshToken();
        
        return tokenDto;
    }
    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}
