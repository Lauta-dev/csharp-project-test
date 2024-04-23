using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;
using Escuela.Models.Alumno;
using Helper.HttpStatusCodes;
using RoutersNames;

namespace Students.Controllers;
public class Students : Controller
{
  private readonly IRequestAlumno _req;

  public Students(IRequestAlumno requestAlumno)
  {
    _req = requestAlumno;
  }

  public object Index()
  {
    return _req.GetStudents();
  }

  [HttpGet("/students/one")]
  public object Student(string id)
  {
    return _req.GetStudentById(id);
  }

  [HttpGet("/students/mul")]
  public object Student(
    [FromQuery(Name = "id")] string id,
    [FromQuery(Name = "limit")] int limit
  )
  {
    return _req.GetStudentByClassroom(id, limit);
  }

  [HttpPost("/students/add")]
  public object A([FromBody] Student[] alumno)
  {
    try
    {
      var e = _req.AddNewStudent(alumno);
      return StatusCode(e.httpCode, e.anyData ?? e.comment);
    }
    catch (ArgumentNullException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (System.Exception e)
    {
      return StatusCode(Codes.InternalServerError, e.InnerException.Message);
    }
  }

  [HttpDelete]
  [Route(DefaultRouts.RemoveStudent)]
  async public Task<object> Delete(string id)
  {
    var data = await _req.RemoveStudent(id);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }
}
