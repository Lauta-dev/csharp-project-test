using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Interface.Base;

namespace Middleware.CheckAll;

public class PayloadModel
{
  public string Mail { get; set; }
  public DateTime DateOfJoining { get; set; }
  public long Exp { get; set; }
  public string Iss { get; set; }
  public string Aud { get; set; }
  public string Rol { get; set; }
}

public class CheckAllRouts : MiddleBase
{
  private readonly RequestDelegate _next;
  private readonly IBase _base;

  public CheckAllRouts(RequestDelegate next, MiddleBase middleBase)
  {
    _next = next;
    _base = middleBase;
  }

  public async Task InvokeAsync(HttpContext ctx)
  {
    if (_base.GetPath(ctx).Contains("account/login") && _base.GetPath(ctx).Contains("admin"))
    {
      await _next(ctx);
      return;
    }


    string bearerToken = _base.GetBearerToken(ctx);

    if (string.IsNullOrEmpty(bearerToken))
    {
      SetStatusCode(ctx, 401);
      await ctx.Response.WriteAsJsonAsync("No se pudo");
      return;
    }

    bearerToken = bearerToken.Split("Bearer")[1].Trim();
    
    JwtSecurityToken TokenHandle = new JwtSecurityTokenHandler().ReadJwtToken(bearerToken);

    JsonSerializerOptions options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    PayloadModel payload = JsonSerializer.Deserialize<PayloadModel>(
      TokenHandle.Payload.SerializeToJson(),
      options
    );
    await _next(ctx);
  }
}
