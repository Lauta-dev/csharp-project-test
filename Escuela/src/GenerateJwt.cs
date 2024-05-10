using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserModel.Person;
using System.Security.Claims;

namespace src.GenerateJwts;
class GenerateJwt
{
    private IConfiguration _config;
    public GenerateJwt(IConfiguration config) { _config = config; }

    public string GenerateJSONWebToken(PersonModel userInfo)
    {
        // El argumento que se le pasa a "GetBytes()" debe ser de 256 bits

        /* Obtiene la representación en bytes de ["Jwt:Key"] */
        var keyToBites = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
        var securityKey = new SymmetricSecurityKey(keyToBites);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
          new Claim("nickname", userInfo.nickname),
          new Claim("id", userInfo.id),
          new Claim("DateOfJoing", DateTime.Now.ToString("d-m-yyyy"))
        };
        
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Issuer"],
          claims,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        try
        {
            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        catch (System.ArgumentOutOfRangeException ex)
        {
            return ex.Message;
        }
    }
}
