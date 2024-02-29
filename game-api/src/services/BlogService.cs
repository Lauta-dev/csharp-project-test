using DB;
using Microsoft.Data.Sqlite;

using BlogNameSpace;
using ResponseObject;
using StatusCodeInt;

namespace Blog.Services
{
  public class BlogDbContextProvider : IBlogDi
  {
    private BlogContext DbContext;
    private CreateResponse result;

    public BlogDbContextProvider(BlogContext context)
    {
      DbContext = context;
      result = new CreateResponse();
    }

    // -------------------------------- //
    
    // Obtener todos los blogs

    // -------------------------------- //

    public CreateResponse GetBlogs()
    {
      try
      {
        if (DbContext.Blog is null) return result;
        
        var blogs = DbContext.Blog.ToList();
        
        if (blogs.Count < 1)
        {
          result = new CreateResponse("No hay blogs", true, Code.GetNotFound(), blogs);
          return result;
        }

        result = new CreateResponse("Todos los Blogs", true, Code.GetOk(), blogs);
        return result;
      } catch (SqliteException ex)
      {
        System.Console.WriteLine("Error al acceder a la base de dato");
        System.Console.WriteLine(ex.Message);
        result = Error500.Error("Error al acceder a la base de dato");

        return result;
      } catch (System.Exception ex)
      {
        System.Console.WriteLine(ex.Message);
        result = Error500.Error("Error interno del servidor");

        return result;
      }
    }
    
    // -------------------------------- //
    
    // Obtener un blog

    // -------------------------------- //

    public CreateResponse GetOneBlog(string id)
    {
      try
      {
        if (DbContext.Blog is null) return result;
        
        var data = DbContext.Blog.FirstOrDefault(x => x.Id == id);

        if (data is null)
        {
          result = new CreateResponse("Blog no encontrado", false, Code.GetNotFound());
          return result;
        }

        result.SetBlogTable(data);
        
        result = new CreateResponse("Blog encontrado", true, Code.GetOk(), result.GetBlogTable());

        return result;
      } catch (SqliteException ex) // En caso de que no se pueda acceder a la base de dato
      {
        System.Console.WriteLine("Error al acceder a la base de dato");
        System.Console.WriteLine(ex.Message);
        result = Error500.Error("Error al acceder a la base de dato");
        return result;
      } catch (System.Exception ex)
      {
        System.Console.WriteLine(ex.Message);
        result = Error500.Error("Error interno del servidor");

        return result;
      }
    }

    // -------------------------------- //
    
    // Crear un blog

    // -------------------------------- //

    public CreateResponse CreateBlog(string url)
    {
      try
      {
        if (url.Length < 1)
        {
          result = new CreateResponse("La URL no puede enviarse vacia", false,  Code.GetNotFound());
          return result;
        }

        var newBlog = new BlogTable { Url = url, Id = Guid.NewGuid().ToString() };
        result = new CreateResponse("El blog fue creado", true, Code.GetOk(), newBlog);
        
        DbContext.Blog.Add(newBlog);
        DbContext.SaveChanges();

        return result;    
      } catch (SqliteException ex) // En caso de que no se pueda acceder a la base de dato
      {
        result = Error500.Error("Error al acceder a la base de dato");
        
        System.Console.WriteLine("Error al acceder a la base de dato");
        System.Console.WriteLine(ex.Message);
        return result;    
      } catch (System.Exception ex)
      {
        System.Console.WriteLine(ex.Message);
        result = Error500.Error();
        return result;
      }
    }

    // -------------------------------- //
    
    // Actualizar un blog

    // -------------------------------- //

    public CreateResponse UpdateBlog(string id, string url)
    {

      try
      {
        var blog = GetOneBlog(id);

        if (blog.GetPass())
        {
          result = new CreateResponse("El registro no existe", false, Code.GetNotFound());
          return result;
        }

        // TODO: Cambiar esto a una forma más entendible
        blog.GetBlogTable().Url = url;
        DbContext.SaveChanges();
        
        result = new CreateResponse("El registro existe", true, Code.GetOk(), blog);
        return result;
      } catch (SqliteException ex) // En caso de que no se pueda acceder a la base de dato
      {
        result = Error500.Error("Error al acceder a la base de dato");
        System.Console.WriteLine("Error al acceder a la base de dato");
        System.Console.WriteLine(ex.Message);
        return result;
      } catch (System.Exception ex)
      {
        result = Error500.Error();
        System.Console.WriteLine(ex.Message);
        return result;
      }
      
    }

    // -------------------------------- //
    
    // Eliminar un blog

    // -------------------------------- //

    public CreateResponse RemoveBlog(string id)
    {
      try
      {
        var getOne = GetOneBlog(id);

        if (!getOne.GetPass())
        {
          result = new CreateResponse("El registro no existe", false, Code.GetNotFound());
          return result;
        }

        if (DbContext.Blog is null) return result;

        DbContext.Blog.Remove(getOne.GetBlogTable());
        DbContext.SaveChanges();
        
        result = new CreateResponse("Registro borrado", true, Code.GetOk(), getOne.GetAllData());
        
        return result;
      } catch (SqliteException ex) // En caso de que no se pueda acceder a la base de dato
      {

        result = Error500.Error("Error al acceder a la base de dato");
        System.Console.WriteLine("Error al acceder a la base de dato");
        System.Console.WriteLine(ex.Message);
        return result;
      } catch (System.Exception ex)
      {
        result = Error500.Error();
        System.Console.WriteLine(ex.Message);
        return result;
      }
    }
  }
}
