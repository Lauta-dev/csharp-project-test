using ResponseObject;

namespace BlogNameSpace;

public interface IBlogDi
{
  public CreateResponse GetBlogs();
  public CreateResponse GetOneBlog(string id);
  public CreateResponse CreateBlog(string url);
  public CreateResponse UpdateBlog(string id, string url);
  public CreateResponse RemoveBlog(string id);
}
