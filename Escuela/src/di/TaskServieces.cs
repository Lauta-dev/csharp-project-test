using SchoolManagement.Task;
using Model.PostTask;
using Escuela.Models.Tarea;
using ConsoleApp.PostgreSQL;
using Helper.Responses;

namespace TaskManagement;
class TaskService : ISchoolManagementTask
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public R AddNewTask(StudentTask[] studentTasks) => StudentTasks.S(_db, studentTasks);
  public R GetTasks() => Model.GetTask.GetTasks.S(_db);
}
