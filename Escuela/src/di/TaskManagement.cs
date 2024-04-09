using Escuela.Models.Tarea;
using Helper.Responses;

namespace SchoolManagement.Task;
public interface ISchoolManagementTask
{
  public R AddNewTask(StudentTask[] studentTasks);
  public R GetTasks();
}
