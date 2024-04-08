using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;
using Escuela.Models.Aulas;

namespace Classroom.Controllers;

public class Classroom : Controller
{
  private readonly IRequestAlumno _req;

  public Classroom(IRequestAlumno requestAlumno)
  {
    _req = requestAlumno;
  }

  public object Index() => _req.GetClassrooms();
  
  [HttpPost("/classroom/new")]
  public object NewClassroom([FromBody] Classrooms[] classrooms)
  {
    try
    {
      var data = _req.AddNewClassrooms(classrooms);
      return StatusCode(data.httpCode, data.anyData ?? data.comment);
    }
    catch (System.NullReferenceException ex)
    {
      return ex.Message;
    }
    catch (System.Exception)
    {
      return "nose";
    }
  }
}
