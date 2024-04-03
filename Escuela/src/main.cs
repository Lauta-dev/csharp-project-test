using Escuela.Configuration;

/* # Cosas por hacer
 *
 * - Controlador para el aula
 * - Hacer la tabla de profesores e tareas
 * - Renombrar HelloWorldControllers por un nombre más formal
 * - Crear tabla de asignaruta
 * - Validaciones en los controller
 * 
 * - Autenticación con JWT
 *    - Poder actualizar información de un usuario
 *    - Poder eliminar un usuario
 *
 * - Crear `Class` de errores
 * - uso correcto de las Responses (retornar un JSON e StatusCode correcto)
 * */

namespace Principal;
class Main
{
  public static void Tuki(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var configServices = new ServiceConfigurator(builder.Services);
    configServices.AddDb();
    configServices.AddScope();
    configServices.AddControllers();
    configServices.JsonConfig();

    var habilitarCors = "ha";
    configServices.Cors(habilitarCors);

    var app = builder.Build();
    app.UseCors(habilitarCors);
    app.MapControllerRoute(name: "default",pattern: "{controller=HOME}/{action=Index}/{id?}");

    app.Run();
  }
}
