using ConsoleApp.PostgreSQL;
using Escuela.Models.Admins;
using Escuela.Models.Alumno;
using Escuela.Models.Base;
using Escuela.Models.TeacherModel;
using Helper.BasicAuthInfo;
using Helper.HashText;
using Helper.HttpStatusCodes;
using Helper.Responses;
using helper.GenerateJwts;

namespace Model.CheckIfExistUser;

public class Persona
{
  public Student student;
  public TeacherModel teacher;
  public Admin admin;
}

class CheckUsers
{
  private readonly SchoolCtx _db;
  private readonly IConfiguration _config;

  public CheckUsers(SchoolCtx db, IConfiguration config)
  {
    _db = db;
    _config = config;
  }

  public ResponseModel Exist(Info info)
  {
    string mail = info.mail;
    string password = info.password;
    string message = "Okay";
    int rol = 0;
    bool pass = false;

    Student? studentDb = _db.student.FirstOrDefault(student => student.Mail == mail);
    TeacherModel? teacherDb = _db.teacher.FirstOrDefault(teacher => teacher.Mail == mail);
    Admin? adminDb = _db.admin.FirstOrDefault(admin => admin.Mail == mail);

    Person[] person = { studentDb, teacherDb, adminDb };

    for (int i = 0; i < person.Length; i++)
    {
      if (person[i] != null)
      {
        password = person[i].Sal + password;

        if (Hashing.Compare(password, person[i].Password))
        {
          rol = person[i].Rol;
          pass = true;
          break;
        }
      }
    }

    if (!pass)
    {
      message = "Unauthorized";
      return new ResponseBuilder(
        message,
        Codes.Unauthorized,
        new { statusCode = Codes.Unauthorized, message }
      ).GetResult();
    }

    string token = new GenerateJwt(_config).GenerateJSONWebToken(info, rol);

    return new ResponseBuilder(
      message,
      Codes.Ok,
      new
      {
        statusCode = Codes.Ok,
        message,
        accessToken = token
      }
    ).GetResult();
  }
}
