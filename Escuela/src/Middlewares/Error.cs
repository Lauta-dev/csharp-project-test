namespace Middleware.Error;
public static class ErrorsMessage
{
  public const string TitleIsNullOrEmpry = "La tarea debe llevar un título";
  public const string ContentIsNullOrEmply = "La tarea debe contar con contenido";
  public const string Important = "La importancia de la tarea debe ser 0 para tareas normales o 1 para tareas de suma importancia";
  public const string StudentIdIsNullOrEmply = "El 'studentId' no es correcto, debe tener 36 caracteres";
  public const string TeacherIdIsNullOrEmply = "El 'teacherId' no es correcto, debe tener 36 caracteres";
  public const string Ok = "La fecha de creación de la tarea es mayor que la fecha actual";
  public const string DateTimeIsInvalit = "Las fechas no tienen un formato válido";
  public const string LimitAtIsLessThenCreateAt = "La fecha de finalización debe ser posterior a la fecha de creación";
  public const string CreateAtIsMoreThenNow = "La fecha de creación de la tarea es mayor que la fecha actual";
}
