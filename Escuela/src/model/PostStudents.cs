using Escuela.Models.Alumno;
using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Npgsql;
using Helper.HttpStatusCodes;
namespace Model.PostStudents;
class PostStudents
{

  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db)
  {
    _db = db;
  }

  public R S(Student[] alumnos)
  {
    try
    {
      string message = "";
      foreach (Student a in alumnos)
      {
        var aula = _db.classroom.FirstOrDefault(e => e.Id == a.ClassroomsId);
        if (aula is null) return new ResponseBuilder("No existe el aula", 404).GetResult();
        if (a.Name == null)
        {
          message = "El valor name debe tener el nombre del estudiante";
          return new ResponseBuilder(
            message,
            Codes.BadRequest,
            new 
            {
              pass = false,
              message,
              statusCode = Codes.BadRequest
            }
          ).GetResult();
        }

        if (a.LastName == null)
        {
          message = "El valor name debe tener el nombre del estudiante";
          return new ResponseBuilder(
            message,
            Codes.BadRequest,
            new 
            {
              pass = false,
              message,
              statusCode = Codes.BadRequest
            }
          ).GetResult();
        }

        if (a.Age == null)
        {
          message = "El valor name debe tener el nombre del estudiante";
            return new ResponseBuilder(
            message,
            Codes.BadRequest,
            new 
            {
              pass = false,
              message,
              statusCode = Codes.BadRequest
            }
          ).GetResult();
        }

        if (a.Age > 13 && a.Age < 18)
        {
          message = "El valor name debe tener el nombre del estudiante";
            return new ResponseBuilder(
            message,
            Codes.BadRequest,
            new 
            {
              pass = false,
              message,
              statusCode = Codes.BadRequest
            }
          ).GetResult();
        }
      }

      _db.student.AddRange(alumnos);
      _db.SaveChanges();

      return new ResponseBuilder("Alumnos añadidos", 200, alumnos).GetResult();
    }
    catch (System.Text.Json.JsonException e)
    {
      return new ResponseBuilder("Alumnos añadidos", 500, e.Message).GetResult();
    }
    catch (NpgsqlException ex)
    {
      System.Console.WriteLine(new {message = "pgsql ex", ex});
      return new ResponseBuilder("Error por parte del server", 500).GetResult();
    }
    catch (System.Exception e)
    {
      if (e.InnerException.Message.Contains("Failed to connect to"))
      {
        return new ResponseBuilder(
          "No se pudo conectar a la base de datos",
          400,
          new
          {
            message = "No se pudo conectar a la base de datos",
            pass = false
          }).GetResult();
      }
      return new ResponseBuilder("Error por nose server", 500).GetResult();

    }
  }
}
