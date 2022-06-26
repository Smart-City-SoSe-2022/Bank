using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Claims;
using System;


namespace bankbackend
{
    public class JWTAutenthication : IJWTAuthentication
    {
        private readonly string key;
        public JWTAutenthication(string key) {
            this.key = key;
        }

        public string Authenticate(string tokenget)
        {
            throw new NotImplementedException();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, tokenget)
            }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenkey),
            SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    
}
