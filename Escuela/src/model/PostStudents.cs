using ConsoleApp.PostgreSQL;
using dto.MappStudentDto;
using dto.StudentDto;
using Escuela.Models.Alumno;
using Helper.HashText;
using Helper.HttpStatusCodes;
using Helper.Responses;
using Helper.UUID;
using Model.Const.Age;
using Model.Const.Message;

namespace Model.PostStudents;

class PostStudents
{
  private readonly SchoolCtx _db;

  public PostStudents(SchoolCtx db)
  {
    _db = db;
  }

  public ResponseModel AddStudents(StudentDto[] students)
  {
    string[] uuid;
    string sal;
    byte[] passwordHashed;

    List<Student> studentList = new List<Student>();

    foreach (StudentDto student in students)
    {
      var aula = _db.classroom.FirstOrDefault(e => e.Id == student.classrooms_id);
      if (aula == null)
        return new ResponseBuilder(Messages.ClassroomsNotFounds, Codes.BadRequest).GetResult();

      if (CheckStudent(student).httpCode != Codes.Ok)
        return CheckStudent(student);

      uuid = UUID.GenerateUUID().Split("-");
      sal = uuid[0] + uuid[4];
      passwordHashed = Hashing.Hash(sal + student.password);

      studentList.Add(Mapper.MapToStudent(student, sal, passwordHashed));
    }

    try
    {
      _db.student.AddRange(studentList);
      _db.SaveChanges();
      _db.Dispose();
      return Response(Messages.SuccessfullyAdded, Codes.Ok);
    }
    catch (System.Text.Json.JsonException e)
    {
      return Response(e.Message);
    }
    catch (System.Exception e)
    {
      return Response(e.Message, Codes.InternalServerError);
    }
  }

  private ResponseModel Response(string message = "not message", int statusCode = Codes.BadRequest)
  {
    return new ResponseBuilder(message, statusCode, new { message, statusCode }).GetResult();
  }

  private ResponseModel CheckStudent(StudentDto student)
  {
    string name = student.name;
    string lastName = student.last_name;
    int age = int.Parse(student.age);
    string mail = student.mail;

    if (string.IsNullOrEmpty(name))
      return Response(Messages.StudentNameIsEmply);

    if (string.IsNullOrEmpty(lastName))
      return Response(Messages.StudentLastNameIsEmply);

    if (age == DefaultAge.Zero)
      return Response(Messages.StudentAgeIsEmply);

    if (age > DefaultAge.MinAge && age < DefaultAge.MaxAge)
      return Response(Messages.StudentAgeRangeErrorMessage);

    return Response("Ok", Codes.Ok);
  }
}
