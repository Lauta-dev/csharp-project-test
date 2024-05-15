using ConsoleApp.PostgreSQL;
using Helper.Responses;

namespace Model.GetTask;

class GetTasks
{
  public static ResponseModel S(SchoolCtx db)
  {
    return new ResponseBuilder("Todas las tareas", 200, db.task).GetResult();
  }
}
