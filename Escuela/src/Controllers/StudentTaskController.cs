using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;
using Escuela.Models.Tarea;

namespace StudentTaskc.Controllers;

public class Task : Controller
{
  private readonly IRequestAlumno _req;

  public Task(IRequestAlumno requestAlumno)
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
    foreach (StudentTask s in tasks)
    {
      System.Console.WriteLine($"id {s.studentId}");
      System.Console.WriteLine($"classroomid: {s.ClassroomsId}");
    }

    var a = _req.AddNewTask(tasks);
    return StatusCode(a.httpCode, a.anyData);
  }
}
