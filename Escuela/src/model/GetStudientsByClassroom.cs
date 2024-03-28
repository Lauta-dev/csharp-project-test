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

    var q = (from a in db.student
             join au in db.classroom on a.AulaId equals au.Id
             where a.AulaId == id
             select new
             {
               aula = au.Aula,
               name = a.Name,
               aulaId = a.AulaId
             }).Take(limit);

    return q;
  }
}
