namespace Model.Const.Message;

public static class Messages
{
  // Classrooms
  public const string ClassroomsNotFounds = "The classroom does not exist";

  // [POST] student
  // --
  public const string StudentNameIsEmply = "Name is null";
  public const string StudentLastNameIsEmply = "Last name is null";
  public const string StudentAgeIsEmply = "Age is emp";
  public const string StudentAgeRangeErrorMessage = "Age invalidate. Age must be between 3 and 2";
  public const string ErrorParceJson = "Error in parsing JSON";

  // --
  public const string SuccessfullyAdded = "Successfully added";

  // [GET] student
  public const string StudentNotFound = "Student not found";
}
