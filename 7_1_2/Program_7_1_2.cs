using _7_1.Entities;

namespace _7_1_2
{
  public static class Program_7_1_2
  {
    public static bool ChangeContractorName(string nameForSearch, string nameToChange)
    {
      using var context = new AppDbContext_7_1_2();

      var query = context.Contractor.Where(c => c.Name.Equals(nameForSearch)).Select(c => c);
      var list = query.ToList();
      if (!list.Any())
      {
        return false;
      }

      var theContractor = list.First();
      theContractor.Name = nameToChange;
      context.SaveChanges(true);
      return true;
    }

    public static RefContractor? CreateContractor(string? name)
    {
      if (name == null)
      {
        return null;
      }

      using var context = new AppDbContext_7_1_2();
      var contractor = new RefContractor() { Name = name };
      context.Contractor.Add(contractor);
      context.SaveChanges(true);
      return contractor;
    }

    public static RefContractor? FindContractor(string byName)
    {
      using var context = new AppDbContext_7_1_2();
      IQueryable<RefContractor> query = context.Contractor.Where(c => c.Name.Equals(byName)).Select(c => c);
      var list = query.ToList();
      if (!list.Any())
      {
        return null;
      }

      return list.First();
    }

    public static bool RemoveContractor(string? name)
    {
      if (name == null)
      {
        return false;
      }
      var theContractor = FindContractor(name);
      if (theContractor == null)
      {
        return false;
      }

      using var context = new AppDbContext_7_1_2();
      context.Contractor.Remove(theContractor);
      context.SaveChanges(true);

      return true;
    }

    private static void AddContractor()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для создания объекта класса RefContractor");
      Console.ReadKey();

      Console.Write("Введите имя новому подрядчику:");
      var theName = Console.ReadLine();

      var contractor = CreateContractor(theName);
      Console.WriteLine($"Добавлен подрядчик с именем {contractor.Name}");
    }

    private static void ChangeContractor()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для изменения свойства Name объекта класса RefContractor");
      Console.ReadKey();

      Console.Write("Введите имя подрядчика, требующее изменения:");
      var theName = Console.ReadLine();

      Console.Write("Введите новое имя подрядчика: ");
      var theNewName = Console.ReadLine();

      if (ChangeContractorName(theName, theNewName))
      {
        Console.Write($"Подрядчик с именем {theName}, изменён. Новое имя: {theNewName}");
        Console.ReadKey();
      }
      else
      {
        Console.Write($"Подрядчик с именем {theName} не найден");
        Console.ReadKey();
      }
    }

    [STAThread]
    private static void Main(string[] args)
    {
      AddContractor();
      ChangeContractor();
      RemoveContractor();
      PrintContractors();
    }

    private static void PrintContractors()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для вывода списка объектов класса RefContractor на экран");
      Console.ReadKey();

      using var context = new AppDbContext_7_1_2();
      foreach (var refContractor in context.Contractor)
      {
        Console.WriteLine();
        Console.WriteLine($"RefContractor: {refContractor.Id}; Name: {refContractor.Name}");
      }

      Console.ReadKey();
    }

    private static void RemoveContractor()
    {
      Console.WriteLine();
      Console.WriteLine("Нажать на любую клавишу для удаления объекта класса RefContractor");
      Console.ReadKey();

      Console.Write("Введите имя подрядчика, требующего удаления:");
      var theName = Console.ReadLine();

      if (RemoveContractor(theName))
      {
        Console.Write($"Подрядчик с именем {theName}, удалён");
        Console.ReadKey();
      }
      else
      {
        Console.Write($"Подрядчик с именем {theName}, не найден");
        Console.ReadKey();
        return;
      }
    }
  }
}