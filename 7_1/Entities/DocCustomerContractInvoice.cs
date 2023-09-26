using System.ComponentModel.DataAnnotations;

namespace _7_1.Entities
{
  public class DocCustomerContractInvoice
  {
    [Key]
    public Guid Id { get; set; }
    public int Price { get; set; }
    public DocCustomerContract Contract { get; set; } = null!;
    public bool IsClosed { get; set; }
  }
}