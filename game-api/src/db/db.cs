using Microsoft.EntityFrameworkCore;

namespace DB
{
  public class BlogContext: DbContext
  {
    // TODO: Agregar valores por defecto y dejar de usar "?" al principo de cada "data type"

    // Representa cada entidad/tabla en la base de dato
    public DbSet<BlogTable>? Blog { get; set; }
    public DbSet<PostTable>? Post { get; set; }
    private string? DbName = "blogging.db";

    // Ruta donde se genera la base de dato
    public string DbPath { get; }

    public BlogContext()
    {
      var path = System.IO.Directory.GetCurrentDirectory(); // Se obtiene el directorio actual
      DbPath = System.IO.Path.Join(path, DbName); // Se concatena el directorio actual con el nombre de la base de dato
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");

  }

  // TODO: Agregar valores por defecto y dejar de usar "?" al principo de cada "data type"
  
  // Entidades/tablas
  public class Blog
  {
    public string Id { get; set; } = "";
    public string Url { get; set; } = "";
  }

  public class BlogTable: Blog
  {
    public List<Post> Posts { get; } = new();
  }

  public class Post
  {
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

    public string? BlogId { get; set; }
  }

  public class PostTable: Post
  {
    public Blog? Blog { get; set; }
  }
}

