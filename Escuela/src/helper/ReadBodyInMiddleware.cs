using System.Text;
using System.Text.Json;
using Helper.Respo;

namespace Helper.ReadBody;

class ReadBodyInMiddleware<T>
{
  public static async Task<R<T>> Read(HttpContext context)
  {
    var req = context.Request;
    req.EnableBuffering();

    byte[] b = new byte[Convert.ToInt32(req.ContentLength)];
    await req.Body.ReadAsync(b, 0, b.Length);

    string r = Encoding.UTF8.GetString(b);
    T g = JsonSerializer.Deserialize<T>(r);

    req.Body.Position = 0;
    return new ResponseBuilder<T>("Todo Correcto", 200, g).GetResult();
  }
}
