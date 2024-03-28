using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;

namespace Classroom.Controllers;

public class Classroom : Controller
{
  private readonly IRequestAlumno _req;

  public Classroom(IRequestAlumno requestAlumno)
  {
    _req = requestAlumno;
  }

  public object Index() => _req.GetClassrooms();

}
