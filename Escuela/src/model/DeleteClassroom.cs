using ConsoleApp.PostgreSQL;
using Helper.HttpStatusCodes;
using Helper.Responses;

namespace Model.DeleteClassrooms;

class DeleteClassroom
{
  private readonly SchoolCtx _db;

  public DeleteClassroom(SchoolCtx db)
  {
    _db = db;
  }

  public async Task<ResponseModel> Remove(string id)
  {
    var checkUser = _db.classroom.FirstOrDefault(x => x.Id == id);
    string message;
    int statusCode;

    if (checkUser == null)
    {
      message = "La clase no existe";
      statusCode = Codes.NotFound;
      return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult();
    }

    _db.classroom.Remove(checkUser);
    await _db.SaveChangesAsync();

    message = "La clase fue eliminada";
    statusCode = Codes.Ok;
    return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult();
  }
}
