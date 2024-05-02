using Escuela.Models.Alumno;
using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Npgsql;
using Helper.HttpStatusCodes;

namespace Model.PostStudents;
class PostStudents
{

  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db) { _db = db; }

  public ResponseModel S(Student[] students)
  {
    foreach (Student student in students)
    {
      var aula = _db.classroom.FirstOrDefault(e => e.Id == student.ClassroomsId);
      if (aula is null) return new ResponseBuilder("No existe el aula", 404).GetResult();
      if (CheckStudent(student).httpCode != Codes.Ok) return CheckStudent(student);
    }
    
    try
    {
      _db.student.AddRange(students);
      _db.SaveChanges();

      return new ResponseBuilder("Alumnos añadidos", 200, students).GetResult();
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

  private ResponseModel CheckStudent (Student student)
  {
    string message = "";

    if (student.Name == null)
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

    if (student.LastName == null)
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

    if (student.Age == 0)
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

    if (student.Age > 13 && student.Age < 18)
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
  
    return new ResponseBuilder("Ok", Codes.Ok).GetResult();
  }
}
