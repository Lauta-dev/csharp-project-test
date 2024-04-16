
namespace Helper.Respo;
public class ResponseBuilder<T>
{
  public string Comment;
  public int HttpCode;
  public T AnyData;

  public ResponseBuilder(string comment, int httpCode, T anyData)
  {
    Comment = comment;
    HttpCode = httpCode;
    AnyData = anyData;
  }

  public ResponseBuilder(string comment, int httpCode)
  {
    Comment = comment;
    HttpCode = httpCode;
  }

  public R<T> GetResult() => new R<T> {
    comment = Comment,
    httpCode = HttpCode,
    anyData = AnyData
  };
}

public class R<T>
{
  public string comment;
  public int httpCode;
  public T anyData;
}
