using ConsoleApp.PostgreSQL;
using Model.Const.Message;

namespace Model.GetStudentById;

public class GetStudentById
{
  private readonly SchoolCtx _db;

  public GetStudentById(SchoolCtx db) { _db = db; }

  public object Students(string id)
  {
    var students = _db.student.FirstOrDefault(student => student.Id == id);

    return students != null
      ? students
      : Messages.StudentNotFound;
  }
}
