using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Task;
using Escuela.Models.Tarea;

namespace StudentTaskc.Controllers;

public class Task : Controller
{
  private readonly ISchoolManagementTask _req;

  public Task(ISchoolManagementTask requestAlumno)
  {
    _req = requestAlumno;
  }

  public object Index()
  {
    var a = _req.GetTasks();
    return StatusCode(a.httpCode, a.anyData);
  }

  [HttpPost("/task/new")]
  public object NewClassroom([FromBody] StudentTask[] tasks)
  {
    var a = _req.AddNewTask(tasks);
    return StatusCode(a.httpCode, a.anyData);
  }
}
