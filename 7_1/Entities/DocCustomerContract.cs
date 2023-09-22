namespace _7_1.Entities
{
  public class DocCustomerContract
  {
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public RefContractor? Contractor { get; set; }
    public RefCustomer? Customer { get; set; }
    public List<RefEmployee> Resources { get; set; } = new List<RefEmployee>();
    public List<DocCustomerContractInvoice> Invoces { get; set; } = new List<DocCustomerContractInvoice>();
  }
}