using Microsoft.IdentityModel.Tokens;
using RecordMedical.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecordMedical.Utility
{
    public class TokenUtility
    {

        private readonly IConfiguration _configuration;
        public TokenUtility(IConfiguration configuration) {
            _configuration = configuration;
                
                }



        public  string TokenGeneration(long userId,string role,string name)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, "user"),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, name),
            
            
            // Issued at time
        };

            var token = CreateToken(claims);
            Console.WriteLine(token);
            return token;


        }


        private  string CreateToken(List<Claim> claims)
        {
            
            Console.WriteLine(_configuration.GetSection("MyApiSettings:ApiKey").Value);
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("MyApiSettings:ApiKey").Value));


            var d = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                  claims: claims,
                  expires: DateTime.Now.AddDays(2),
                  signingCredentials: d

              );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;


        }


    }
}
