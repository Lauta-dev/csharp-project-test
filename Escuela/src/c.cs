using Helper.Responses;
using Escuela.Models.Aulas;
using Helper.HttpStatusCodes;
using System.Text.RegularExpressions;

namespace Control;
class Ca
{
  public static R Ad(Classrooms[] classrooms)
  {
    bool error = false;
    string pattern = @"^\d+-[A-Z]$";
    string message = "";

    foreach (Classrooms classroom in classrooms)
    {
      if (!Regex.IsMatch(classroom.Aula, pattern))
      {
        message = "El aula debe estar en este formato: 1-A";
        error = true;
        return new ResponseBuilder(
          message,
          Codes.BadRequest,
          new
          {
            pass = false,
            comment = message,
            statusCode = Codes.BadRequest,
            classrooms

          }
        ).GetResult();
      }
    }

    message = "Paso con exito";
    error = false;
    return new ResponseBuilder(
      message,
      Codes.Ok,
      new
      {
        pass = true,
        comment = message,
        statusCode = Codes.BadRequest,
        classrooms
      }
    ).GetResult();
  }
}
