using Interface.Base;

public class MiddleBase : IBase
{
  public string GetPath(HttpContext ctx) => ctx.Request.Path;

  public string GetMethod(HttpContext ctx) => ctx.Request.Method;

  public void SetStatusCode(HttpContext ctx, int code) => ctx.Response.StatusCode = code;

  public IHeaderDictionary GetHeaders(HttpContext ctx) => ctx.Request.Headers;

  public string GetBearerToken(HttpContext ctx) => ctx.Request.Headers["Authorization"];
}
