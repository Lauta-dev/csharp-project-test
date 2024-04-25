using Helper.Responses;
using ConsoleApp.PostgreSQL;
using Helper.HttpStatusCodes;

namespace Model.DeleteTasks;
class DeleteTask
{
  private readonly SchoolCtx _db;
  public DeleteTask(SchoolCtx db) { _db = db; }

  async public Task<R> Delete(string taskId, string teacherId)
  {
    var check = Check(teacherId, taskId);

    if (!check)
      return new ResponseBuilder("No se puedo borrar la tarea", Codes.BadRequest).GetResult();

    var task = _db.task.FirstOrDefault(t => t.Id == taskId);
    _db.task.Remove(task);
    
    await _db.SaveChangesAsync();
    return new ResponseBuilder("Tarea borrada con exito", Codes.Ok).GetResult();
  }

  private bool Check(string teacherId, string taskId)
  {
    var teacher = _db.teacher.FirstOrDefault(t => t.Id == teacherId);
    var task = _db.task.FirstOrDefault(t => t.Id == taskId);
    
    if (task == null || teacher == null) return false;
    if (task.teacherId != teacher.Id) return false;

    return true;
  }
}

