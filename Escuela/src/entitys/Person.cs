using Helper.UUID;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Escuela.Models.Base;
public class Person
{
  [Column("id")]
  public string Id { get; } = UUID.GenerateUUID();

  [Column("name")]
  public string? Name { get; set; }

  [Column("last_name")]
  public string? LastName { get; set; }

  [Column("age")]
  public int? Age { get; set; }

  [Column("fecha_de_nacimiento")]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime FechaDeNacimiento { get; set; }
}
