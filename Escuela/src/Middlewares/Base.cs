namespace Middleware.Base;
public class MiddleBase
{
  public string GetPath(HttpContext ctx) => ctx.Request.Path;
  public string GetMethod(HttpContext ctx) => ctx.Request.Method;

  async public void Exceptions(
  System.Exception ex,
  HttpContext ctx,
  int statusCode = 500,
  string messagea = null
)
  {
    string message = messagea ?? ex.Message;

    ctx.Response.StatusCode = statusCode;
    var data = new Helper.Responses.ResponseBuilder(
      message,
      statusCode,
      new { statusCode = statusCode, message, serverMessage = ex.Message }
    ).GetResult();
    await ctx.Response.WriteAsJsonAsync(data.anyData);
  }
}
