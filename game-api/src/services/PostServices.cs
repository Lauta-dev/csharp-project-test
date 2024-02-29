
using DB;
using PostDependencyInjection;
using ResponseObject;
using StatusCodeInt;

namespace Post.Services
{
  public class PostDbContextProvider : IPostDi
  {
    private BlogContext _db;
    private CreateResponse result;

    public PostDbContextProvider(BlogContext context)
    {
      _db = context;
      result = new CreateResponse();
    }

    // ------------------------------- \\
  
    // Obtener todos los post
  
    // ------------------------------- \\

    public CreateResponse GetPosts(int take, int skip)
    {
      if (_db.Post is null) return result;

      var post = _db.Post.Take(take).Skip(skip).ToList();
      result = new CreateResponse("Todos los posts", true, Code.GetOk(), post);
      return result;
    }
    
    // ------------------------------- \\
  
    // Obtener post por id
  
    // ------------------------------- \\

    public CreateResponse GetByPostId(string id)
    {
      if (_db.Post is null) return result;
      var post = _db.Post.FirstOrDefault(x => x.Id == id);

      if (post is null)
      {
        result = new CreateResponse("El post no existe", false, Code.GetNotFound(), new string[0]);
        return result;
      }

      result.SetPostTable(post);
      result = new CreateResponse("Post encontrado", true, Code.GetOk(), post, post);

      return result;
    }
    
    // ------------------------------- \\
  
    // Añadir un post
  
    // ------------------------------- \\ 
    
    public CreateResponse CreatePost(string title, string content)
    {
      string id = Guid.NewGuid().ToString();
      
      var newPost = new PostTable {
        Id = id,
        Title = title,
        Content = content,
        BlogId = "f2261ad6-4a1a-4b4f-80f6-5e414c7264ea"
      };
      
      _db.Post.Add(newPost);
      result = new CreateResponse("Post agregado", true, Code.GetOk(), newPost);
      _db.SaveChanges();
      System.Console.WriteLine("Se añadio el post");
      return result;
    }

    // ------------------------------- \\
  
    // Actualizar un post
  
    // ------------------------------- \\

    public CreateResponse UpdatePost(string id, string title, string content)
    {
      // TODO: Realizar la actualización de datos

      return result;
    }


    // ------------------------------- \\
  
    // Eliminar un post por id
  
    // ------------------------------- \\

    // System.ArgumentNullException: Value cannot be null. (Parameter 'entity')
    public CreateResponse RemovePost(string id)
    {
      try
      {
        var getPostFromDb = GetByPostId(id);

        if (!getPostFromDb.GetPass())
        {
          
          result = new CreateResponse("El post no existe", false, Code.GetNotFound());
          return result;
        }

        result = new CreateResponse("El post fue eliminado", true, Code.GetOk(), getPostFromDb.GetData());

        _db.Post.Remove(getPostFromDb.GetPostTable());
        _db.SaveChanges();

        return result;         
       }
      catch (ArgumentNullException ex)
      {
        result = Error500.Error(ex.Message);
        return result;
      }
      catch (Exception ex)
      {
        result = Error500.Error(ex.Message);
        return result;
      }
    }
  }
}
