namespace _7_1.SampleClasses
{
  public class DocumentContractorClass
  {
    public DocumentClass? DocumentLink { get; set; }
    public ContractorClass? ContractorLink { get; set; }

    public string Identifier { get; } = Guid.NewGuid().ToString();

    public bool IsValid => (DocumentLink != null && ContractorLink != null);
  }
}