using ResponseObject;

namespace PostDependencyInjection;

public interface IPostDi
{
  public CreateResponse GetPosts(int take, int skip);
  public CreateResponse GetByPostId(string id);
  public CreateResponse CreatePost(string title, string content);
  public CreateResponse UpdatePost(string id, string title, string content);
  public CreateResponse RemovePost(string id);
}
