namespace Tk;
class Adds
{
  public object? StudentId { get; set; }
  public string TeacherId { get; set; } = "null";
  public string ClassroomId { get; set; } = "null";
  public string Title { get; set; } = "null";
  public string Content { get; set; } = "null";

  public DateTime CreateAt { get; set; }
  public DateTime LimitAt { get; set; }
}
