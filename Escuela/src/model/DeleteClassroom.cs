using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Helper.HttpStatusCodes;

namespace Model.DeleteClassrooms;
class DeleteClassroom
{
  private readonly SchoolCtx _db;

  public DeleteClassroom(SchoolCtx db)
  {
    _db = db;
  }
  
  public R Remove(string id)
  {
    var db = _db;
    var checkUser = db.classroom.FirstOrDefault(x => x.Id == id);
    string message;
    int statusCode;

    if (checkUser == null)
    {
      message = "La clase no existe";
      statusCode = Codes.NotFound;
      return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult(); 
    }

    message = "La clase fue eliminada";
    statusCode = Codes.Ok;
    return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult(); 
  }
}
