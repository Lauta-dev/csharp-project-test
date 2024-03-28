using ConsoleApp.PostgreSQL;

namespace Model.GetStudentById;

public class GetStudentById
{
  private readonly SchoolCtx _db;

  public GetStudentById(SchoolCtx db) {
    _db = db;
  }

  public object Student(string id)
  {
    var student = _db.student.FirstOrDefault(s => s.Id == id);

    if (student is null)
    {
      return "No exite el alumno";
    }

    return student;
  }
}
