namespace Helper.Responses;

public class ResponseBuilder
{
  public string Comment;
  public int HttpCode;
  public object AnyData;

  public ResponseBuilder(string comment, int httpCode, object anyData)
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

  public ResponseModel GetResult() =>
    new ResponseModel
    {
      comment = Comment,
      httpCode = HttpCode,
      anyData = AnyData
    };
}

public class ResponseModel
{
  public string comment;
  public int httpCode;
  public object anyData;
}
