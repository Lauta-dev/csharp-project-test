using System.Net;

namespace Helper.HttpStatusCodes;

class Codes
{
  // -> 2xx
  public const int Ok = (int)HttpStatusCode.OK;

  // -> 4xx
  public const int BadRequest = (int)HttpStatusCode.BadRequest;
  public const int NotFound = (int)HttpStatusCode.NotFound;
  public const int NotAcceptable = (int)HttpStatusCode.NotAcceptable;
  public const int Unauthorized = (int)HttpStatusCode.Unauthorized;

  // -> 5xx
  public const int InternalServerError = (int)HttpStatusCode.InternalServerError;
}
