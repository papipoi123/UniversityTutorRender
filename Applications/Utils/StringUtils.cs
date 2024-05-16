using Applications.Commons;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Applications.Utils
{
    public static class StringUtils
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        public static string Salt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
        public static string GenerateJwtToken(this User user, JWTSection jwt)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: new[] { new Claim("Id", user.Id.ToString()),
                                    new Claim("email", user.Email.ToString()),
                                    new Claim("role", user?.Role?.Rolename?.ToString()?? throw new Exception("Server Error:Role Not found!")),
                                    new Claim("avatar", user?.Image?? ""),
                                    new Claim("username", user?.FullName?? "")
                                  },
                    expires: DateTime.Now.AddDays(Convert.ToDouble(jwt.ExpiresInDays)),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
