using ConsoleApp.PostgreSQL;

namespace Model.GetStudentsByClassroom;

class GetStudentsByClassroom
{
  private readonly SchoolCtx _db;

  public GetStudentsByClassroom(SchoolCtx db)
  {
    _db = db;
  }

  public object S(string id, int limit = 10)
  {
    var db = _db;
    System.Console.WriteLine(id);

    var q = db.student.Join(
      db.classroom,
      student => student.ClassroomsId,
      classroom => classroom.Id,
      (s, c) =>
        new
        {
          name = s.Name,
          classroom = c.Aula,
          classId = c.Id
        }
    );

    return new
    {
      info = new
      {
        next = limit > q.Count() ? 0 : q.Count() - limit,
        prev = limit < 5 ? limit : limit - 5,

        get = limit,
        from = q.Count(),
      },

      data = q.Where(s => s.classId == id).Take(limit)
    };
  }
}
