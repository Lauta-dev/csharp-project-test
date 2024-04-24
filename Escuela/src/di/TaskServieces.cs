using SchoolManagement.Task;
using Model.PostTask;
using Escuela.Models.Tarea;
using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Model.DeleteTasks;

namespace TaskManagement;
class TaskService : ISchoolManagementTask
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public R AddNewTask(StudentTask[] studentTasks) => StudentTasks.S(_db, studentTasks);
  public R GetTasks() => Model.GetTask.GetTasks.S(_db);
  async public Task<R> RemoveTask(string taskId, string teacherId)
    => await new DeleteTask(_db).Delete(taskId, teacherId);
}
