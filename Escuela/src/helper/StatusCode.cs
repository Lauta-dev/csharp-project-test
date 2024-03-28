using System.Net;
namespace Tuk;
class HttpCodeStatus
{
  public const int Ok = (int)HttpStatusCode.OK;
  public const int InternalServerError = (int)HttpStatusCode.InternalServerError;
  public const int BadRequest = (int)HttpStatusCode.BadRequest;
  public const int NotFound = (int)HttpStatusCode.NotFound;
}
