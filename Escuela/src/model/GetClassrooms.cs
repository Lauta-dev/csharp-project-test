using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Helper.HttpStatusCodes;
using Model.Const.Message;

namespace Model.GetClassrooms;

public class GetClassrooms
{
  private readonly SchoolCtx _db;

  public GetClassrooms(SchoolCtx db) { _db = db; }

  public ResponseModel Classrooms()
  {
    // TODO: evitar los objectos con valores null
    var classrooms = _db.classroom.ToList();

    ResponseModel response (string message, int statusCode, object? moreData = null)
    {
      moreData = moreData == null ? new { } : moreData;
      return new ResponseBuilder(message, statusCode, new { message, statusCode, moreData }).GetResult();
    }

    return classrooms.Count == 0
      ? response(Messages.ClassroomsNotFounds, Codes.BadRequest)
      : response(Messages.ClassroomsFounds, Codes.Ok, classrooms);
  }
}
