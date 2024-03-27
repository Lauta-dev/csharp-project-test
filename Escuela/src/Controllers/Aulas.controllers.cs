using Microsoft.AspNetCore.Mvc;
using Escuela.Models.Aulas;
using ConsoleApp.PostgreSQL;

namespace MinAPISeparateFile;

public static class AulasControllers
{
  public static void MapAulas(WebApplication app)
  {
    app.MapPost("/agregar-clase", ([FromBody] Aulas aula, BloggingContext db) =>
    {
      db.Aulas.Add(new Aulas { Aula = aula.Aula });
      db.SaveChanges();
      return "data";
    });

    app.MapGet("/aulas", (BloggingContext db) =>
    {
      var data = db.Aulas.ToList();
      return data;
    });
  }
}
