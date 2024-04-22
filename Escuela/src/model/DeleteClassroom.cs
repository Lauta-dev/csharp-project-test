using ConsoleApp.PostgreSQL;
using Helper.Responses;

namespace Model.DeleteClassrooms;
class DeleteClassroom
{
  private readonly SchoolCtx _db;

  public DeleteClassroom(SchoolCtx db) {
    _db = db;
  }

  public R Remove(string id)
  {
    var db = _db;
    var checkUser = db.classroom.FirstOrDefault(x => x.Id == id);
    
    if (checkUser == null)
    {
      return new ResponseBuilder("La clase no existe", 404).GetResult(); 
    }

    db.classroom.Remove(checkUser);
    db.SaveChanges();
    return new ResponseBuilder("Clase eliminada con exito", 200).GetResult();
  }

}
