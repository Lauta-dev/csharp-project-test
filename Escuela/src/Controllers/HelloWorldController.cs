using Microsoft.AspNetCore.Mvc;
using SchoolManagement.AlumnoRe;
using Escuela.Models.Alumno;
using Tuk;

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
      return _req.AddNewStudent(alumno);  
    }
    catch (ArgumentNullException ex)
    {
      return BadRequest(ex.Message);
    }
    catch (System.Exception e)
    {
      return StatusCode(HttpCodeStatus.InternalServerError, e.Message);
    }
  }
}
