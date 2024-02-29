using DB;
using StatusCodeInt;

namespace ResponseObject;
public class CreateResponse
{
  // Valores por default
  const string      MessageDefault          = "";
  const bool        PassDefault             = false;
  const int         StatusCodeDefault       = 200;
  const object      DataDefault             = null;
  const BlogTable   BlogtableDataDefault    = null;
  const PostTable   PosttableDataDefault    = null;

  protected string      Message         { get; set; } = MessageDefault;
  protected bool        Pass            { get; set; } = PassDefault;
  protected int         StatusCode      { get; set; } = StatusCodeDefault;
  protected object      Data            { get; set; } = DataDefault;
  protected BlogTable   BlogTableData   { get; set; } = BlogtableDataDefault;
  protected PostTable   PostTableData   { get; set; } = PosttableDataDefault;


  public CreateResponse(string message, bool pass, int statusCode, object data, BlogTable blogTable)
  {
    Message = message;
    Pass = pass;
    StatusCode = statusCode;
    Data = data;
    BlogTableData = blogTable;
  }

  public CreateResponse(string message, bool pass, int statusCode, object data, PostTable postTable)
  {
    Message = message;
    Pass = pass;
    StatusCode = statusCode;
    Data = data;
    PostTableData = postTable;
  }

  public CreateResponse(string message, bool pass, int statusCode, object data)
  {
    Message = message;
    Pass = pass;
    StatusCode = statusCode;
    Data = data;
  }

  public CreateResponse(string message, bool pass, int statusCode)
  {
    Message = message;
    Pass = pass;
    StatusCode = statusCode;
  }

  public CreateResponse(int statusCode, bool pass, object data) {
    StatusCode = statusCode;
    Pass = pass;
    Data = data;
  }
  
  public CreateResponse() {}

  // Getters
  public string     GetMessage()     => Message;
  public bool       GetPass()        => Pass;
  public int        GetStatusCode()  => StatusCode;
  public object     GetData()        => Data;
  public BlogTable  GetBlogTable()   => BlogTableData;
  public PostTable  GetPostTable()   => PostTableData;

  // Setters
  public void SetBlogTable(BlogTable blog) => BlogTableData = blog;
  public void SetPostTable(PostTable post) => PostTableData = post;

  // Methods
  public object GetAllData()
  {
    var format = new {
      message = Message,
      pass = Pass,
      statusCode = StatusCode,
      data = Data,
      blogTable = BlogTableData
    };

    return format;
  }

  public object ReturnInfoIfPostIsDelete()
  {
    var post = GetPostTable();

    var format = new {
      id = post.Id,
      title = post.Title,
      content = post.Content
    };

    return format;
  }

  public object ReturnInfoIfBlogIsDelete()
  {
    var blog = GetBlogTable();

    var format = new {
      id = blog.Id,
      url = blog.Url,
    };

    return format;
  }
}

public class Error500
{
  public static CreateResponse Error(string message = "Error desconocido")
  {
    return new CreateResponse(message, false, Code.GetInternalServerError());
  }
}
