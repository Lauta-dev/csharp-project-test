using ConsoleApp.PostgreSQL;
using Escuela.Models.Tarea;
using Helper.Responses;
using Model.DeleteTasks;
using Model.PostTask;
using SchoolManagement.Task;

namespace TaskManagement;

class TaskService : ISchoolManagementTask
{
  private readonly SchoolCtx _db = new SchoolCtx();

  public ResponseModel AddNewTask(StudentTask[] studentTasks) => StudentTasks.S(_db, studentTasks);

  public ResponseModel GetTasks() => Model.GetTask.GetTasks.S(_db);

  public async Task<ResponseModel> RemoveTask(string taskId, string teacherId) =>
    await new DeleteTask(_db).Delete(taskId, teacherId);
}
