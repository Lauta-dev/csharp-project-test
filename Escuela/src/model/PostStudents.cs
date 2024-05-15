using Escuela.Models.Alumno;
using ConsoleApp.PostgreSQL;
using Helper.Responses;
using Helper.HttpStatusCodes;
using Model.Const.Message;
using Model.Const.Age;

namespace Model.PostStudents;
class PostStudents
{
  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db) { _db = db; }

  public ResponseModel AddStudents(Student[] students)
  {
    foreach (Student student in students)
    {
      var aula = _db.classroom.FirstOrDefault(e => e.Id == student.ClassroomsId);
      if (aula == null) return new ResponseBuilder(Messages.ClassroomsNotFounds, Codes.BadRequest).GetResult();
      if (CheckStudent(student).httpCode != Codes.Ok) return CheckStudent(student);
    }
    
    try
    {
      _db.student.AddRange(students);
      _db.SaveChanges();

      return Fu(Messages.SuccessfullyAdded, Codes.Ok);
    }
    catch (System.Text.Json.JsonException e)
    {
      return Fu(e.Message);
    }
    catch (System.Exception e)
    {
      return Fu(e.Message, Codes.InternalServerError);
    }
  }

  private ResponseModel Fu(string message = "not message", int statusCode = Codes.BadRequest) {
    return new ResponseBuilder(
      message,
      statusCode,
      new  { message, statusCode }
    ).GetResult();
  }

  private ResponseModel CheckStudent (Student student)
  {
    string name = student.Name;
    string lastName = student.LastName;
    int age = student.Age;
    int rol = student.Rol;
    string mail = student.Mail;

    if (string.IsNullOrEmpty(name))
      return Fu(Messages.StudentNameIsEmply);

    if (string.IsNullOrEmpty(lastName))
      return Fu(Messages.StudentLastNameIsEmply);

    if (age == DefaultAge.Zero)
      return Fu(Messages.StudentAgeIsEmply);

    if (age > DefaultAge.MinAge && age < DefaultAge.MaxAge)
      return Fu(Messages.StudentAgeRangeErrorMessage);

    return Fu("Ok", Codes.Ok);
  }
}
