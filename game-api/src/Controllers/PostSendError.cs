using StatusCodeInt;

namespace PostSendError
{
  class ErrorClass
  {
    public static object Error(string msj) => 
      new {
        message = msj,
        pass = false,
        statusCode = Code.GetBadRequest()
      };
  }
}
