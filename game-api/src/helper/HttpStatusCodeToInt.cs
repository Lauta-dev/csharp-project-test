using System.Net;
namespace StatusCodeInt;

// TODO: Remplazar esta clase con un ENUM
static public class Code
{
  // 200
  static int Ok = (int)HttpStatusCode.OK;
  static int NoContent = (int)HttpStatusCode.NoContent;

  // 400
  static int NotFound = (int)HttpStatusCode.NotFound;
  static int BadRequest = (int)HttpStatusCode.BadRequest;
  
  // 500
  static int InternalServerError = (int)HttpStatusCode.InternalServerError;

  // Methods
  public static int GetOk() => Ok;
  public static int GetNoContent() => NoContent;
  
  public static int GetNotFound() => NotFound;
  public static int GetBadRequest() => BadRequest;
  
  public static int GetInternalServerError() => InternalServerError;
}
