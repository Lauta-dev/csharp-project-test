using ConsoleApp.PostgreSQL;
using Escuela.Models.Alumno;
using Helper.BasicAuthInfo;
using Helper.HashText;
using Helper.HttpStatusCodes;
using Helper.Responses;

namespace Model.CheckIfExistUser;

class CheckUsers
{
  private readonly SchoolCtx _db;

  public CheckUsers(SchoolCtx db)
  {
    _db = db;
  }

  public ResponseModel Exist(Info info)
  {
    Student? studentDb = _db.student.FirstOrDefault(student => student.Mail == info.mail);
    string message = "Okay";

    if (studentDb == null)
    {
      message = "Unauthorized";
      return new ResponseBuilder(
        message,
        Codes.Unauthorized,
        new { statusCode = Codes.Unauthorized, message }
      ).GetResult();
    }

    string password = studentDb.Sal + info.password.Trim();
    bool checkPass = Hashing.Compare(password, studentDb.Password);

    if (!checkPass)
    {
      message = "Contraseña incorrecta";
      return new ResponseBuilder(
        message,
        Codes.NotAcceptable,
        new { statusCode = Codes.Unauthorized, message }
      ).GetResult();
    }

    return new ResponseBuilder(
      message,
      Codes.Ok,
      new { statusCode = Codes.Ok, message }
    ).GetResult();
  }
}
