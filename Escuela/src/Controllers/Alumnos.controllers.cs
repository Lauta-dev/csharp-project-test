using ConsoleApp.PostgreSQL;
using Microsoft.AspNetCore.Mvc;
using Escuela.Models.Alumno;
using DateParsing;
using Interface.Alumno;
using FiltrosAula;

namespace MinAPISeparateFile;

public class AlumnosControllers
{
  private readonly IRequestAlumno _req;

  public AlumnosControllers(IRequestAlumno requestAlumno)
  {
    _req = requestAlumno;
  }

  public void MapAlumno(WebApplication app)
  {
    app.MapGet("/alumnos", (BloggingContext db) =>
    {

      var i = "374beb45-997c-44e2-9f58-937cba026322";

      var q = from a in db.Alumnos
              join au in db.Aulas on a.AulaId equals au.Id
              where a.AulaId == i
              select new
              {
                aula = au.Aula,
                name = a.Name,
                aulaId = a.AulaId
              };
      if (db.Alumnos.ToList().Count < 1)
      {
        return Results.BadRequest("asd");
      }

      var userFormat = new List<object>();

      foreach (Alumno alumno in db.Alumnos.ToList())
      {
        userFormat.Add(new
        {
          name = alumno.Name,
          lastName = alumno.LastName,
          id = alumno.Id,
          age = alumno.Age,
          aulaId = alumno.AulaId,
          fechaDeNacimiento = DateParse.FormatDate(alumno.FechaDeNacimiento.ToString())
        });
      }

      return Results.Ok(new { q, userFormat });
    });

    // TODO: FIltrar por
    //    - ID
    //    - Aula
    //    - Limite ? limit : limit = 10
    // NOTE: Se me ocurre ordenar nombre y fechas, no se si hacer por el backend
    app.MapGet("/alumno", (
      [FromQuery(Name = "id")] string? id,
      [FromQuery(Name = "limit")] int? limit,
      BloggingContext db
    ) =>
    {
      System.Console.WriteLine(new { id, limit });
      if (limit is null) limit = 2;

      var q = (from a in db.Alumnos
               join au in db.Aulas on a.AulaId equals au.Id
               where a.AulaId == id
               select new
               {
                 aula = au.Aula,
                 name = a.Name,
                 aulaId = a.AulaId
               }).Take((int)limit);

      return Results.Ok(q);
    });

    app.MapPost("/agregar-alumno", ([FromBody] Alumno[] alumno, BloggingContext db) =>
    {
      foreach (Alumno a in alumno)
      {
        var aula = db.Aulas.FirstOrDefault(e => e.Id == a.AulaId);

        if (aula is null) return Results.BadRequest("No existe el aula");

        var data = new Alumno
        {
          Name = a.Name,
          LastName = a.LastName,
          Age = a.Age,
          FechaDeNacimiento = a.FechaDeNacimiento,
          AulaId = a.AulaId
        };

        db.Alumnos.Add(data);

        db.SaveChanges();
      }

      return Results.Ok(new { message = $"El usuario asd fue agregado" });
    });
  }
}
