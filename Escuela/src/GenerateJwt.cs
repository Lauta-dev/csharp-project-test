using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Helper.BasicAuthInfo;
using Microsoft.IdentityModel.Tokens;

namespace src.GenerateJwts;

class GenerateJwt
{
  private IConfiguration _config;

  public GenerateJwt(IConfiguration config)
  {
    _config = config;
  }

  public string GenerateJSONWebToken(Info info, int rol)
  {
    var keyToBites = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
    var securityKey = new SymmetricSecurityKey(keyToBites);
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim("mail", info.mail),
      new Claim("rol", rol.ToString()),
      new Claim("DateOfJoing", DateTime.Now.ToString("d-m-yyyy"))
    };

    var token = new JwtSecurityToken(
      _config["Jwt:Issuer"],
      _config["Jwt:Issuer"],
      claims,
      expires: DateTime.Now.AddMinutes(120),
      signingCredentials: credentials
    );

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
