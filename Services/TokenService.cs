using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoList.Models;

namespace TodoList.Services {
    public class TokenService {

        private readonly string _jwtKey;

        public TokenService(IConfiguration configuration) {
            _jwtKey = configuration.GetValue<string>("JwtKey") ?? null!;
        }

        public string GenerateToken(User user) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity( new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                }),

                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };      
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
