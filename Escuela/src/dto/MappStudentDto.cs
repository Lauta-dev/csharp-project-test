using Escuela.Models.Alumno;

namespace dto.MappStudentDto;

class Mapper
{
  public static Student MapToStudent(StudentDto.StudentDto studentDto, string sal, byte[] password)
  {
    return new Student
    {
      Name = studentDto.name,
      LastName = studentDto.last_name,
      Age = int.Parse(studentDto.age),
      Rol = 0,
      Mail = studentDto.mail,
      Sal = sal,
      Password = password,
      ClassroomsId = studentDto.classrooms_id,
      FechaDeNacimiento = studentDto.date_of_birth,
    };
  }
}
