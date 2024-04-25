using Escuela.Models.Tarea;
using Helper.Responses;

namespace SchoolManagement.Task;
public interface ISchoolManagementTask
{
  public ResponseModel AddNewTask(StudentTask[] studentTasks);
  public ResponseModel GetTasks();
  public Task<ResponseModel> RemoveTask(string taskId, string teacherId);
}
