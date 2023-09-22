namespace _7_1.SampleClasses
{
  public class DocumentDisposableClass : IDisposable
  {
    public string? Name { get; set; }
    public bool IsDisposed { get; private set; } = false;

    public void Dispose()
    {
      // TODO release managed resources here
      Console.WriteLine($"object of DocumentDisposableClass with name='{Name}' has disposed");
      IsDisposed = true;
    }
  }
}