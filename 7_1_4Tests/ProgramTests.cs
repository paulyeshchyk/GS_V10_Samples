using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7_1_4.Tests
{
  [TestClass()]
  public class ProgramTests
  {
    [TestMethod()]
    public void NewContractTest()
    {
      Assert.IsNotNull(_context);
      var contract = Program_7_1_4.NewContract(context: _context, "Subject2", "Contractor2");
      Assert.IsNotNull(contract);
      Assert.IsNotNull(contract.Contractor);
      Assert.AreEqual("Subject2", contract.Subject);
      Assert.AreEqual(contract.Contractor.Name, "Contractor2");
    }

    [TestMethod()]
    public void AddContractorTest()
    {
      Assert.IsNotNull(_context);
      var contractor = Program_7_1_4.AddContractor(context: _context, "Contractor3");
      Assert.IsNotNull(contractor);
      Assert.AreEqual(contractor.Name, "Contractor3");
    }

    [TestMethod()]
    public void AddContractTest()
    {
      Assert.IsNotNull(_context);
      var contract = Program_7_1_4.AddContract(context: _context, "Contract3");
      Assert.IsNotNull(contract);
      Assert.AreEqual(contract.Subject, "Contract3");
    }

    private AppDbContext_7_1_4? _context;

    [TestCleanup]
    public void TestCleanup()
    {
      if (_context == null)
      {
        Assert.IsTrue(false);
        return;
      }
      _context.Database.RollbackTransaction();
    }

    [TestInitialize]
    public void TestInitialize()
    {
      if (_context != null)
      {
        Assert.IsTrue(false);
        return;
      }

      var factory = new AppDbContextFactory_7_1_4();
      _context = factory.CreateDbContext(Array.Empty<string>());
      _context.Database.EnsureCreated();
      if (_context == null) { return; }
      _context.Database.BeginTransaction();
    }
  }
}