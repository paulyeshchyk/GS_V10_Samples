using System.ComponentModel.DataAnnotations;

namespace _7_1.Entities
{
  public class RefCustomer
  {
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
  }
}