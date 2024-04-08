using ConsoleApp.PostgreSQL;
using Escuela.Models.Aulas;
using System.Text.RegularExpressions;
using WebApi.Responses;
using HttpStatusCodes;

namespace Model.PostClassroom;
class PostClassroom
{
  private readonly SchoolCtx _db;

  public PostClassroom(SchoolCtx db)
  {
    _db = db;
  }

  public R Classroom(Classrooms[] classrooms)
  {
    bool error = false;
    string pattern = @"^\d+-[A-Z]$";

    foreach (Classrooms classroom in classrooms)
    {
      if (int.TryParse(classroom.Aula, out _))
      {
        error = true;
        return new ResponseBuilder(
          "Las clases no deben ser un número, deben ser del estilo 'A-1, A-2, B-1, B-2'",
          Codes.BadRequest,
          new
          {
            pass = false,
            comment = "Las clases no deben ser un número, deben ser del estilo 'A-1, A-2, B-1, B-2'",
            statusCode = Codes.BadRequest,
            classrooms
          }
        ).GetResult();
      }

      if (!Regex.IsMatch(classroom.Aula, pattern))
      {
        error = true;
        return new ResponseBuilder(
          "El aula debe estar en este formato: 1-A",
          Codes.BadRequest,
          new
          {
            pass = false,
            comment = "El aula debe estar en este formato: 1-A",
            statusCode = Codes.BadRequest,
            classrooms

          }
        ).GetResult();
      }

      if (_db.classroom.FirstOrDefault(x => x.Aula.ToLower() == classroom.Aula.ToLower()) != null)
      {
        error = true;
        return new ResponseBuilder(
          "Esta clase ya existe",
          Codes.BadRequest,
          new
          {
            pass = false,
            comment = "Esta clase ya existe",
            statusCode = Codes.BadRequest,
            classrooms

          }
        ).GetResult();
      }
    }

    if (error)
    {
      return new ResponseBuilder(
          "Error al agregar las clases",
          400,
          new
          {
            pass = false,
            comment = "Error al agregar las clases",
            statusCode = 400,
            classrooms

          }
        ).GetResult();
    }

    _db.classroom.AddRange(classrooms);
    _db.SaveChanges();
    return new ResponseBuilder(
        "Clases agregadas",
        200,
        new
        {
          pass = true,
          comment = classrooms.Length > 1 ? "Clases agregadas" : "Clase agregada",
          statusCode = 200,
          classrooms
        }
      ).GetResult();
  }
}
