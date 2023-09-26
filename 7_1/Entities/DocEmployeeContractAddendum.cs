using System.ComponentModel.DataAnnotations;

namespace _7_1.Entities
{
  public class DocEmployeeContractAddendum
  {
    [Key]
    public Guid Id { get; set; }
    public DocEmployeeContract Contract { get; set; } = null!;
    public string Addendum { get; set; } = string.Empty;
    public bool IsValid { get; set; } = true;
  }
}