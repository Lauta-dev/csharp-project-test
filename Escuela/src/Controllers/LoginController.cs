using Microsoft.AspNetCore.Mvc;
using src.GenerateJwts;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Helper.BasicAuthInfo;
using Helper.ValidateEmails;

namespace Login.Controllers;
public class Account : Controller
{
    private readonly IConfiguration _config;
    public Account(IConfiguration config) { _config = config; }

    [HttpPost]
    public Object Login([FromBody] Info user)
    {
        // TODO:
        // - Validar que el mail exista en la base de datos
        // - Dependiento si es alumno o profesor se le da un rol

        string res = "Mail no valido";

        if (Validate.Mail(user.mail))
            return Results.Ok(new { access_token = new GenerateJwt(_config).GenerateJSONWebToken(user) });


        return Results.BadRequest(res);
    }

    [Authorize]
    public Object Auth()
    {
        string getToken = HttpContext.Request.Headers["Authorization"].ToString().Split("Bearer")[1].Trim();

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
