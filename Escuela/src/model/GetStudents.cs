using ConsoleApp.PostgreSQL;
using Escuela.Models.Alumno;
using Helper.DateParsing;

namespace Model.GetStudents;

public class GetStudents
{
  private readonly SchoolCtx _db;

  public GetStudents(SchoolCtx db)
  {
    _db = db;
  }

  public List<object> GetStudent()
  {
    var userFormat = new List<object>();

    foreach (Student alumno in _db.student.ToList())
    {
      userFormat.Add(
        new
        {
          name = alumno.Name,
          lastName = alumno.LastName,
          id = alumno.Id,
          age = alumno.Age,
          aulaId = alumno.ClassroomsId,
          fechaDeNacimiento = DateParse.FormatDate(alumno.DateOfBirth.ToString())
        }
      );
    }

    return userFormat;
  }
}
