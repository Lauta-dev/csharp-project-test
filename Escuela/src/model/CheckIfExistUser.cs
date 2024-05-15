using ConsoleApp.PostgreSQL;
using Escuela.Models.Alumno;
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

  public ResponseModel Exist(string mail)
  {
    Student? user = _db.student.FirstOrDefault(student => student.Mail == mail);
    string message = "Okay";

    if (user == null)
    {
      message = "Unauthorized";
      return new ResponseBuilder(
        message,
        Codes.Unauthorized,
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
