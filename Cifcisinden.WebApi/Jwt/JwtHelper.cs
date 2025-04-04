using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Cifcisinden.WebApi.Jwt;

public static class JwtHelper
{
    public static string GenerateJwtToken(JwtDto jwtInfo)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecretKey));

        //credentials -> Kimlik bilgileri.

        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtClaimNames.Id, jwtInfo.Id.ToString()),
            new Claim(JwtClaimNames.FirstName, jwtInfo.FirstName),
            new Claim(JwtClaimNames.LastName, jwtInfo.LastName),
            new Claim(JwtClaimNames.Email, jwtInfo.Email),
            new Claim(JwtClaimNames.UserType, jwtInfo.UserType.ToString()),
            
            new Claim(ClaimTypes.Role, jwtInfo.UserType.ToString())
        };

        var expireTime = DateTime.Now.AddMinutes(jwtInfo.ExpireMinutes);

        var tokenDescriptor = new JwtSecurityToken(jwtInfo.Issuer, jwtInfo.Audience, claims, null, expireTime, credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return token;
    }

}
