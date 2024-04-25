using ConsoleApp.PostgreSQL;
using Escuela.Models.Tarea;
using Helper.Responses;

namespace Model.PostTask;
public class StudentTasks
{
  public static ResponseModel S(SchoolCtx db, StudentTask[] studentTasks)
  {
    db.task.AddRange(studentTasks);
    db.SaveChanges();
    return new ResponseBuilder("Add new task", 200, studentTasks).GetResult();
  }
}
