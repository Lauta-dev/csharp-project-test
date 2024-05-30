namespace Interface.Base;

interface IBase
{
  public string GetPath(HttpContext ctx);
  public string GetMethod(HttpContext ctx);
  public void SetStatusCode(HttpContext ctx, int code);
  public IHeaderDictionary GetHeaders(HttpContext ctx);
  public string GetBearerToken(HttpContext ctx);
}
