using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helper.UUID;

namespace Escuela.Models.Base;
public class Person
{
  [Column("id")]
  public string Id = UUID.GenerateUUID();

  [Column("name")]
  public string Name { get; set; }

  [Column("last_name")]
  public string LastName { get; set; }

  [Column("age")]
  public int Age { get; set; }

  [Column("rol")]
  public int Rol { get; set; } = 0;

  [Column("mail")]
  public string mail { get; set; }

  [Column("fecha_de_nacimiento")]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime FechaDeNacimiento { get; set; }
}
