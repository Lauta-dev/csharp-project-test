using Users;
using Messages;

namespace GetUserForId
{
  class P
  {
    private static List<User> users = LoadUser.CreateUser.usersList;
    public static object GetUser(string id)
    {
      if (!int.TryParse(id, out _))
      {
        var comment = new IfIdNotANumber().GetMessage();

        return Results.BadRequest(comment);
      } 

      // Si el usuario no existe devuelve false
      var user = users.Exists(e => e.id == id);

      // Si el usuario no existe
      if (!user)
      {
        var message = new {
          message = "Este usuario no existe",
          statuscode = StatusCodes.Status404NotFound
        };
        return Results.NotFound(message);
      }

      // Retorna un `JSON` formateado
      return Results.Json(users.Find(e => e.id == id));
    }
  }
}
