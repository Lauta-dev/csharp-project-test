using ConsoleApp.PostgreSQL;
using Helper.Responses;

namespace Model.GetTeachers;

class GetTeachers
{
  public static ResponseModel S(SchoolCtx db)
  {
    return new ResponseBuilder("Todos los profesores", 200, db.teacher).GetResult();
  }
}
