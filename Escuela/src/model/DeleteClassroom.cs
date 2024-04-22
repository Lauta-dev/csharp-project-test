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
  
  async public Task<R> Remove(string id)
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
