using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PDD.NET.WebApi.Services
{
    public static class TokenManager
    {
        public static string GenerateToken(string username)
        {
            /*        byte[] key = Convert.FromBase64String(Secret);
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
                    SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] {
                                  new Claim(ClaimTypes.Name, username)}),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(securityKey,
                        SecurityAlgorithms.HmacSha256Signature)
                    };

                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
                    return handler.WriteToken(token);*/
            return "";
        }
    }

}
