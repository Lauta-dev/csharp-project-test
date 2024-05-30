using System.IdentityModel.Tokens.Jwt;
using Helper.BasicAuthInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.CheckUser;

namespace Login.Controllers;

public class Account : Controller
{
  private readonly IConfiguration _config;
  private readonly ICheckUser _checkUser;

  public Account(IConfiguration config, ICheckUser checkUser)
  {
    _config = config;
    _checkUser = checkUser;
  }

  [HttpPost]
  public Object Login([FromBody] Info user)
  {
    var checkUser = _checkUser.CheckUser(user);
    return StatusCode(checkUser.httpCode, new { checkUser.anyData });
  }


  public Object Auth()
  {
    string getToken = HttpContext
      .Request.Headers["Authorization"]
      .ToString()
      .Split("Bearer")[1]
      .Trim();

    try
    {
      var handler = new JwtSecurityTokenHandler().ReadJwtToken(getToken);
      var payload = handler.Payload["mail"].ToString();

      if (String.IsNullOrEmpty(payload))
        throw new ArgumentNullException();

      return payload;
    }
    catch (ArgumentNullException ex)
    {
      return StatusCode(404, ex.Message);
    }
    catch (Microsoft.IdentityModel.Tokens.SecurityTokenMalformedException ex)
    {
      return StatusCode(404, ex.Message);
    }
    catch (ArgumentException ex)
    {
      return StatusCode(404, ex.Message);
    }
    catch (System.Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }
}
