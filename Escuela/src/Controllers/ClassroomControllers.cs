using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Classroom;
using Escuela.Models.Aulas;
using RoutersNames;

namespace Classroom.Controllers;

public class Classroom : Controller
{
  private readonly ISchoolManagementClassroom _req;

  public Classroom(ISchoolManagementClassroom classroom)
  {
    _req = classroom;
  }

  public object Index() => _req.GetClassrooms();
  
  [HttpPost(DefaultRouts.ClassroomNew)]
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
