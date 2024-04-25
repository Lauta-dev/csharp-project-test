using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Teacher;
using Escuela.Models.TeacherModel;

namespace Teacher.Controllers;

public class Teacher : Controller
{
  private readonly ISchoolManagementTeacher Req;

  public Teacher(ISchoolManagementTeacher schoolManagement)
  {
    Req = schoolManagement;
  }

  public object Index()
  {
    var data = Req.GetAllTeacher();
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }

  [HttpPost("/teacher/new")]
  public object NewClassroom([FromBody] TeacherModel[] teacher)
  {
    var data = Req.AddNewTeacher(teacher);
    System.Console.WriteLine(data.httpCode);
    return StatusCode(data.httpCode, data.anyData ?? data.comment);
  }

  [HttpDelete]
  async public Task<object> Delete(string id)
  {
    string[] ids = id.Split(",");

    var data = await Req.RemoveTeachers(ids);
    return StatusCode(data.httpCode, data);
  }
}

