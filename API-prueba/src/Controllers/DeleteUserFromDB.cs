using ReturnAllUsers;
using System.Net;

namespace DeleteUserFromDB
{
  class DeleteUser
  {
    private static List<Users.User> users = UserCollection.users;

    private static object SearchUser(string id)
    {
      // Ver si existe el usuario
      var checkUserIfExist = users.Exists(x => x.id == id);

      if (checkUserIfExist)
      {
        DeleteUsera(id);
        return "El usuario fue eliminado";
      }
      
      return "El usuario no existe";
        
    }

    private static void DeleteUsera(string id)
    {
      // Volver a recorrer la lista para filtrar todos los usuario que no tengan el id de turno
      var user = (from n in users where n.id != id select n).ToList();
      UserCollection.users = user;

      // TODO: evitar re-asignar el atributo
      // Se me ocurre crear un constructor y cargar los datos desde alli, pero no se si sea buena practica
      users = user;
    }

    public static object Delete(string id)
    {
      if (!int.TryParse(id, out _))
      {
        var comment = new {
          message = "El valor tiene que ser numérico",
          statusCode = HttpStatusCode.BadRequest,
          yourValue = id
        };

        return Results.BadRequest(comment);
      }

      return SearchUser(id);
    }
  }
}
