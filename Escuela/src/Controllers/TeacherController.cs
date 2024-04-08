using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;
using Escuela.Models.TeacherModel;

namespace Teacher.Controllers;

public class Profe : Controller
{
  private readonly IRequestAlumno _req;

  public Profe(IRequestAlumno requestAlumno)
  {
    _req = requestAlumno;
  }

  public object Index()
  {
    var data = _req.GetAllTeacher();
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }

  [HttpPost("/profe/new")]
  public object NewClassroom([FromBody] TeacherModel[] teacher)
  {
    var data = _req.AddNewTeacher(teacher);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }
}

