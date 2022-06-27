using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Claims;
using System;
using Newtonsoft.Json.Linq;

namespace bankbackend
{
    public class JWTdecode
    {
        public int GetID(string token)
        {
            var stream = token;
            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(stream);
            string test = jsonToken.ToString();
            Console.WriteLine(test);
            string[] decoded = test.Split('.');
            string[] idbefor=decoded[1].Split(',');
            string ids = idbefor[0];

          
            string phrase = ids.Remove(0,6);

            ids = phrase.Replace("\"", "");
            Console.WriteLine(ids);
            int id =int.Parse(ids);
            
            return id;
        }

       
        

    }
}
