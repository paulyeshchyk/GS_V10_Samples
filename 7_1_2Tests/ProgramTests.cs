using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7_1_2.Tests
{
  [TestClass()]
  public class ProgramTests
  {

    [TestMethod()]
    public void ConnectionAvailabilityTest()
    {
      Assert.IsTrue(_context.Database.CanConnect(), "Connection is not available");
    }

    [TestMethod()]
    public void FindContractorTest()
    {
      var contractor = Program_7_1_2.CreateContractor("Name1");
      Assert.IsNotNull(contractor);

      var contractror1 = Program_7_1_2.FindContractor("Name1");
      Assert.IsNotNull(contractror1);

      var guid = Guid.NewGuid();
      var guidContractor = Program_7_1_2.FindContractor(guid.ToString());
      Assert.IsNull(guidContractor);

      Assert.IsNotNull(_context);

      foreach (var refContractor in _context.Contractor.Where(c => c.Name.Equals("Name1")))
      {
        _context.Contractor.Remove(refContractor);
      }

      _context.SaveChanges();
    }

    [TestMethod()]
    public void FindContractorThatIsNotAvailableTest()
    {
      var guid = Guid.NewGuid();
      var contractor = Program_7_1_2.FindContractor(guid.ToString());
      Assert.IsNull(contractor);
    }

    [TestMethod()]
    public void RemoveContractorThatIsNotAvailableTest()
    {
      var guid = Guid.NewGuid();
      var theResult = Program_7_1_2.RemoveContractor(guid.ToString());

      Assert.IsFalse(theResult);
    }

    [TestMethod()]
    public void CreateAndRemoveContractorTest()
    {
      var guid = Guid.NewGuid();
      var contractor = Program_7_1_2.CreateContractor(guid.ToString());
      Assert.IsNotNull(contractor);

      var theResult = Program_7_1_2.RemoveContractor(guid.ToString());
      Assert.IsTrue(theResult);
    }

    [TestMethod()]
    public void ChangeContractorNameTest()
    {
      var guid = Guid.NewGuid().ToString();
      var contractor = Program_7_1_2.CreateContractor(guid);
      Assert.IsNotNull(contractor);

      var guid2 = Guid.NewGuid().ToString();
      var changed = Program_7_1_2.ChangeContractorName(guid, guid2);
      Assert.IsTrue(changed);

      var removed = Program_7_1_2.RemoveContractor(guid2);
      Assert.IsTrue(removed);
    }

    private AppDbContext_7_1_2? _context;

    private Lazy<AppDbContext_7_1_2> InitContext()
    {

      AppDbContextFactory_7_1_2 _factory = new AppDbContextFactory_7_1_2();
      return new(() => _factory.CreateDbContext(Array.Empty<string>()));
    }

    [TestCleanup]
    public void TestCleanup()
    {
      if (_context == null)
      {
        Assert.IsTrue(false, "Context is null");
        return;
      }
      _context.Database.RollbackTransaction();
    }

    [TestInitialize]
    public void TestInitialize()
    {

      this._context = this.InitContext().Value;

      Assert.IsTrue(_context.Database.CanConnect(), "Connection is not available");

      _context.Database.EnsureCreated();
      _context.Database.BeginTransaction();
    }
  }

}