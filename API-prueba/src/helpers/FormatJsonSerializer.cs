/*
 *  Este modulo sirve para obtener un JSON y devuelve el mismo JSON pero formateado
 * */

using System.Text.Json;

namespace FormatJson
{
  class FormatJsonSerializer
  {
    public static string Format(object user)
    {
      var options = new JsonSerializerOptions()
      {
        WriteIndented = true
      };

      return JsonSerializer.Serialize(user, options);
    }
  }
}
