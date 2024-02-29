using DB;
using Blog.Services;
using Post.Services;
using BlogNameSpace;
using PostDependencyInjection;

namespace StartApp
{
  class Start
  {
    public static void Init(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var services = builder.Services;
      services.AddControllers();

      // Lo que hace ASP.NET es gestionar las instancias de la clase y llamarlas cuando se necesiten
      services.AddDbContext<BlogContext>();

      // Aplicar la injeccion de dependencia en controllers
      //services.AddSingleton<IDateTime, SystemDateTime>();
      services.AddScoped<IBlogDi, BlogDbContextProvider>();
      services.AddScoped<IPostDi, PostDbContextProvider>();

      var app = builder.Build();

      app.UseCors(b => b.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

      // Este ejemplo lo saque de
      // https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-7.0
      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      System.Console.WriteLine("|----------------------------------------------------------------|");
      System.Console.WriteLine("|-------                                                  -------|");
      System.Console.WriteLine("|                        INICIO DE LA APP                        |");
      System.Console.WriteLine("|-------                                                  -------|");
      System.Console.WriteLine("|----------------------------------------------------------------|");

      app.Run();
    }
  }
}
