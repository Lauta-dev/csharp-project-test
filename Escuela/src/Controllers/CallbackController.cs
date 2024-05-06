using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Classroom;

namespace Callback.Controllers;

public class Callback : Controller
{
  private readonly ISchoolManagementClassroom _req;
  public Callback(ISchoolManagementClassroom classroom) { _req = classroom; }

  public object Index() 
  {
    System.Console.WriteLine("Tota");
    return "Tota";
  }
}
