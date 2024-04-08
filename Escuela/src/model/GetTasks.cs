using Helper.Responses;
using ConsoleApp.PostgreSQL;

namespace Model.GetTask;
class GetTasks
{
  public static R S(SchoolCtx db)
  {
    return new ResponseBuilder("Todas las tareas", 200, db.task).GetResult();
  }
}
