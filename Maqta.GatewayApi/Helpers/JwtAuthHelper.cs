using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Maqta.GatewayApi
{
    public interface IJwtAuthHelper
    {
        string Authenticate(string username, string password, int expiry);
    }
    public class JwtAuthHelper : IJwtAuthHelper
    {
        private Dictionary<string, string> employees = new Dictionary<string, string>
        { {"user1","pass1"}};
        private readonly string _key;
        public JwtAuthHelper(string secret)
        {
            _key = secret;
        }
        public string Authenticate(string username, string password, int expiry)
        {
            if (!employees.Contains(new KeyValuePair<string, string>(username, password)))
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Role, "Admin")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiry),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }

}

