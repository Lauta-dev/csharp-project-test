using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Classroom;
using Escuela.Models.Aulas;

namespace Classroom.Controllers;

public class Classroom : Controller
{
  private readonly ISchoolManagementClassroom _req;

  public Classroom(ISchoolManagementClassroom classroom)
  {
    _req = classroom;
  }

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
  async public Task<object> Delete(string id)
  {
    var data = await _req.RemoveClassrooms(id);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }
}
