using Helper.Responses;
using Escuela.Models.Aulas;
using System.Text.RegularExpressions;

namespace Middleware.CheckBody;
class CheckBody
{
  public ResponseModel Check(Classrooms[] classrooms)
  {
    // Chekear si hay duplicados
    var checkDuplicate = classrooms.DistinctBy(x => x.Aula);

    string comment = "Paso con exito";
    int statusCode = 200;
    string pattern = @"^\d+-[A-Z]$";

    if (checkDuplicate.Count() != classrooms.Length)
    {
      comment = "Repeated values are not permitted";
      statusCode = 400;
      return new ResponseBuilder(comment, statusCode, new { comment, statusCode }).GetResult();
    }

    for (int i = 0; i < classrooms.Length; i++)
    {
      Classrooms classroom = classrooms[i];
      if (!Regex.IsMatch(classroom.Aula, pattern))
      {
        comment = "Incorrect format";
        statusCode = 400;
        return new ResponseBuilder(comment, statusCode, new { comment, statusCode, data = classrooms.Where(x => x != null).ToArray() }).GetResult();
      }
    }

    return new ResponseBuilder(comment, statusCode, new { comment, statusCode }).GetResult();
  }
}

