using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;


namespace _7_1.Entities
{
  public class RefContractor
  {
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
  }
}