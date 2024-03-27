using Helper.UUID;
using System.ComponentModel.DataAnnotations.Schema;

/*id
aula
titulo
contenido
fecha_creacion
fecha_limite
toda_el_aula (bool)
estado (1,2,3)*/

/*
 *id_profesor reference Profesores
id_alumno reference Alumnos
 * */

namespace Escuela.Models.Tarea;
public class Tarea {
  public string Id = UUID.GenerateUUID();

  [Column("aula")]
  public string Aula { get; set; }

  [Column("titulo")]
  public string Titulo { get; set; }

  [Column("contenido")]
  public string Contenido { get; set; }
  
}
