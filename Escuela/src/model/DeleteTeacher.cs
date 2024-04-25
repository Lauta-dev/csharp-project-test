using Helper.Responses;
using Helper.HttpStatusCodes;

using ConsoleApp.PostgreSQL;

using Escuela.Models.TeacherModel;

namespace Model.DeleteTeachers;
class DeleteTeacher
{
  private readonly SchoolCtx _db;
  public DeleteTeacher(SchoolCtx db) { _db = db; }

  async public Task<R> Delete(string[] ids)
  {
    List<TeacherModel> teachers = new List<TeacherModel>();

    for (int i = 0; i < ids.Length; i++)
    {
      var data = _db.teacher.FirstOrDefault(x => x.Id == ids[i]);

      System.Console.WriteLine(data == null);

      // NOTE: Se supone que al no encontrar profesores,
      // este devuevlve null, pero no es asi, los profesores se añaden incorrectamente al Array teachers
      if (data != null)
        teachers.Add(data); 
    }

    if (teachers.Count == 0) return new ResponseBuilder("", Codes.BadRequest).GetResult();

    _db.teacher.RemoveRange(teachers);
    await _db.SaveChangesAsync();

    return new ResponseBuilder("", Codes.Ok).GetResult();
  }
}
