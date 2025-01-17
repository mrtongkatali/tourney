using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using tourney.api.Models;

namespace tourney.api.Services
{
    public class JwtService
    {
       private readonly string _secretKey;
       private readonly string _issuer;
       private readonly string _audience;

       public JwtService(IConfiguration configuration)
       {
           _secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException(nameof(configuration), "Jwt:SecretKey is not configured.");
           _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException(nameof(configuration), "Jwt:Issuer is not configured.");
           _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException(nameof(configuration), "Jwt:Audience is not configured.");
       }

       public string GenerateToken(User user)
       {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(999),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
       }
    }
}