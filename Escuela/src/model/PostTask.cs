using ConsoleApp.PostgreSQL;
using Escuela.Models.Tarea;
using WebApi.Responses;

namespace Model.PostTask;
public class StudentTasks
{
  public static R S(SchoolCtx db, StudentTask[] studentTasks)
  {
    db.task.AddRange(studentTasks);

    db.SaveChanges();
    return new ResponseBuilder("Add new task", 200, studentTasks).GetResult();
  }
}
