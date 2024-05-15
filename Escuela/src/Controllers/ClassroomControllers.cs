using Escuela.Models.Aulas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Classroom;

namespace Classroom.Controllers;

[Authorize]
public class Classroom : Controller
{
  private readonly ISchoolManagementClassroom _req;

  public Classroom(ISchoolManagementClassroom classroom)
  {
    _req = classroom;
  }

  [AllowAnonymous]
  public object Index()
  {
    var data = _req.GetClassrooms();
    return StatusCode(data.httpCode, data.anyData);
  }

  [HttpPost]
  public object New([FromBody] Classrooms[] classrooms)
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

  [HttpDelete]
  public async Task<object> Delete(string id)
  {
    var data = await _req.RemoveClassrooms(id);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }
}
