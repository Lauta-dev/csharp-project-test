using System.IdentityModel.Tokens.Jwt;

namespace Helper.validateToken;

public class ValidateToken
{
  public static bool Validate(string? token)
  {
    bool isNullorEmply = string.IsNullOrEmpty(token);

    if (isNullorEmply)
      return false;

    var a = new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
    return true;
  }
}
