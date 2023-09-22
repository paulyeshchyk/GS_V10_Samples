using _7_1.Entities;
using System.Runtime.InteropServices;

namespace _7_1_4
{
  public static class Program_7_1_4
  {
    [DllImport("Kernel32")]
    private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

    private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

    private enum CtrlType
    {
      CTRL_C_EVENT = 0,
      CTRL_BREAK_EVENT = 1,
      CTRL_CLOSE_EVENT = 2,
      CTRL_LOGOFF_EVENT = 5,
      CTRL_SHUTDOWN_EVENT = 6
    }

    private static bool Handler(CtrlType signal)
    {
      switch (signal)
      {
        case CtrlType.CTRL_BREAK_EVENT:
        case CtrlType.CTRL_C_EVENT:
        case CtrlType.CTRL_LOGOFF_EVENT:
        case CtrlType.CTRL_SHUTDOWN_EVENT:
        case CtrlType.CTRL_CLOSE_EVENT:
          Console.WriteLine("Closing");
          // TODO Cleanup resources
          _context.Database.RollbackTransaction();
          Environment.Exit(0);
          return false;

        default:
          return false;
      }
    }

    private static AppDbContext_7_1_4 _context;

    [STAThread]
    private static void Main(string[] args)
    {
      // Register the handler
      SetConsoleCtrlHandler(Handler, true);

      var factory = new AppDbContextFactory_7_1_4();
      _context = factory.CreateDbContext(Array.Empty<string>());
      _context.Database.EnsureCreated();
      _context.Database.BeginTransaction();

      var subject = "Subject1";
      var contractor = "Contractor1";
      _ = NewContract(context: _context, subject, contractor);

      Console.WriteLine($"Created contract: {subject} with {contractor}");

      while (true)
      {
        Thread.Sleep(50);
      }
    }

    public static DocCustomerContract NewContract(AppDbContext_7_1_4 context, string subject, string contractorName)
    {
      var contractor = AddContractor(context: context, contractorName);
      var contract = AddContract(context, subject);
      contract.Contractor = contractor;
      context.SaveChanges();
      return contract;
    }

    public static RefContractor AddContractor(AppDbContext_7_1_4 context, string name)
    {
      var result = new RefContractor() { Name = name };
      context.Contractor.Add(result);
      return result;
    }

    public static DocCustomerContract AddContract(AppDbContext_7_1_4 context, string name)
    {
      var result = new DocCustomerContract() { Subject = name };
      context.CustomerContract.Add(result);
      return result;
    }
  }
}