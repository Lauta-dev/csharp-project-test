using Escuela.Models.Alumno;
using Helper.HttpStatusCodes;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;

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

  [HttpGet]
  public object One(string id)
  {
    return _req.GetStudentById(id);
  }

  [HttpGet]
  public object Mul([FromQuery(Name = "id")] string id, [FromQuery(Name = "limit")] int limit)
  {
    return _req.GetStudentByClassroom(id, limit);
  }

  [HttpPost]
  public object New([FromBody] Student[] alumno)
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
  public async Task<object> Delete(string id)
  {
    var data = await _req.RemoveStudent(id);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }
}
