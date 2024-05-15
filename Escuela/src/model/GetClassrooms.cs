using ConsoleApp.PostgreSQL;
using Helper.HttpStatusCodes;
using Helper.Responses;
using Microsoft.EntityFrameworkCore;
using Model.Const.Message;

namespace Model.GetClassrooms;

public class GetClassrooms
{
  private readonly SchoolCtx _db;

  public GetClassrooms(SchoolCtx db)
  {
    _db = db;
  }

  public ResponseModel Classrooms()
  {
    // TODO: evitar los objectos con valores null
    var classrooms = _db.classroom.OrderBy(c => c.Aula).Select(c => c.Aula).ToArray();

    ResponseModel response(string message, int statusCode, object? moreData = null)
    {
      moreData = moreData == null ? new { } : moreData;
      return new ResponseBuilder(
        message,
        statusCode,
        new
        {
          message,
          statusCode,
          moreData
        }
      ).GetResult();
    }

    return classrooms.Length == 0
      ? response(Messages.ClassroomsNotFounds, Codes.BadRequest)
      : response("Ok", Codes.Ok, classrooms);
  }
}
