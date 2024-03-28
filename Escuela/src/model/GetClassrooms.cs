using ConsoleApp.PostgreSQL;

namespace Model.GetClassrooms;

public class GetClassrooms
{
  private readonly SchoolCtx _db;

  public GetClassrooms(SchoolCtx db) {
    _db = db;
  }

  public object Classrooms()
  {
    var data = _db.classroom.ToList();
    return data;
  }
}
