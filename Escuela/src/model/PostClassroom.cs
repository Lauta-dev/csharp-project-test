using ConsoleApp.PostgreSQL;
using Escuela.Models.Aulas;
using System.Text.RegularExpressions;
using Helper.Responses;
using Helper.HttpStatusCodes;

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
    System.Console.WriteLine("asdsa");

    foreach (Classrooms classroom in classrooms)
    {
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
