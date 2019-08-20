using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public class AuthService : IAuthService
    {
        public string GenerateToken(string username)
        {
            string securityToken = "Yes__indeed. It_is_called_Lothric__where_the_transitory_lands_of_the_Lords_of_Cinder_converge.";

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityToken));

            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
                {
                    new Claim("username", username),
                };

            var token = new JwtSecurityToken(
                issuer: "fukuah",
                audience: "readers",
                expires: DateTime.Now.AddHours(4),
                signingCredentials: signingCredential,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
