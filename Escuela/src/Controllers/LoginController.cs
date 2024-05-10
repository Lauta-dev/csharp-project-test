using Microsoft.AspNetCore.Mvc;
using UserModel.Person;
using src.GenerateJwts;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Login.Controllers;
public class Account : Controller
{
    private readonly IConfiguration _config;
    public Account(IConfiguration config) { _config = config; }

    [HttpPost]    
    public Object Login([FromBody] PersonModel user)
    {
        string token = new GenerateJwt(_config).GenerateJSONWebToken(user);

        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine(user.id);
        return token;
    }

    [Authorize]
    public Object Auth()
    {
      string getToken = HttpContext.Request.Headers["Authorization"].ToString().Split("Bearer")[1].Trim();
      var handler = new JwtSecurityTokenHandler().ReadJwtToken(getToken);
      var payload = handler.Payload["nickname"];

      return payload;
    }
}
