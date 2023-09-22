using _7_1.SampleClasses;

namespace _7_1_1
{
  public static class Program_7_1_1
  {
    [STAThread]
    private static void Main(string[] args)
    {
      SampleIDisposableAndUsing();
      SampleIDisposableAndDispose();
      SampleGcCollect();
      SampleWaitForKey();
    }

    private static void SampleGcCollect()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для создания объекта и удаления его из памяти используя подход GC.Collect();");
      Console.ReadKey();
      for (var i = 0; i < 3; i++)
      {
        var objLoop = new DocumentClass() { Name = $"Name{10 + i}" };
        Console.WriteLine($"DocumentClass.Name = {objLoop.Name}");
      }

      for (var i = 0; i < 10000; i++)
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }

    private static void SampleIDisposableAndDispose()
    {
      Console.WriteLine();
      Console.WriteLine(
        "Нажать на любую клавишу для создания объекта, поддерживающего протокол IDisposable, и удаления его из памяти используя подход Dispose();");
      Console.ReadKey();
      var obj2 = new DocumentDisposableClass() { Name = "Name2" };
      Console.WriteLine($"DocumentDisposableClass.Name = {obj2.Name}");
      obj2.Dispose();
    }

    private static void SampleIDisposableAndUsing()
    {
      Console.WriteLine();
      Console.WriteLine(
        "Нажать на любую клавишу для создания объекта, поддерживающего протокол IDisposable, и удаления его из памяти используя подход using(var..){};");
      Console.ReadKey();
      using var obj = new DocumentDisposableClass() { Name = "Name1" };
      Console.WriteLine($"DocumentDisposableClass.Name = {obj.Name}");
    }

    private static void SampleWaitForKey()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для завершения работы");
      Console.ReadKey();
    }
  }
}