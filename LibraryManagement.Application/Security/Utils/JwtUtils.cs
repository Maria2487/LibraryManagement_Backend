using LibraryManagement.Application.DTOs.Account;
using LibraryManagement.Application.Settings;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagement.Application.Security.Utils
{
    public class JwtUtils : IJwtUtils
    {
        private readonly TokenSettings tokenSettings;
        public JwtUtils(IOptions<TokenSettings> tokenSettings) => this.tokenSettings = tokenSettings.Value;
        public string GenerateToken(User user)
        {
            var secretKey = tokenSettings.TokenKey;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {   new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("role", user.Role.ToString())
                }),
                Issuer = tokenSettings.Issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public AuthenticatedUserData? ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }

            var secretKey = tokenSettings.TokenKey;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var AuthentificatedUserData = new AuthenticatedUserData()
                {
                    UserId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    Email = jwtToken.Claims.First(x => x.Type == "email").Value,
                    Role = jwtToken.Claims.First(x => x.Type == "role").Value,
                };

                return AuthentificatedUserData;
            }
            catch
            {
                return null;
            }
        }
    }
}
