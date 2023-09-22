namespace _7_1.SampleClasses
{
  public class DocumentClass
  {
    public string? Name { get; init; }

    ~DocumentClass()
    {
      Console.WriteLine($"object of DocumentClass with name='{Name}' has destroyed");
    }
  }
}