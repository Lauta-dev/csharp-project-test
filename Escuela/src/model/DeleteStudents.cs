using Helper.Responses;
using ConsoleApp.PostgreSQL;
using Helper.HttpStatusCodes;

namespace Model.DeleteStudents;
class DeleteStudent
{
  private readonly SchoolCtx _db;

  public DeleteStudent(SchoolCtx db) { _db = db; }

  async public Task<R> Delete(string id)
  {
    var user = _db.student.FirstOrDefault(u => u.Id == id);
    int statusCode;
    string comment;

    if (user == null)
    {
      comment = "No se encontro al alumno";
      statusCode = Codes.NotFound;
      return new ResponseBuilder(comment, statusCode, new { comment, statusCode }).GetResult();
    }

    statusCode = Codes.Ok;
    comment = "El alumno se borro de la base de datos";

    _db.student.Remove(user);
    await _db.SaveChangesAsync();
    return new ResponseBuilder(comment, statusCode, new { comment, statusCode }).GetResult();
  }
}
