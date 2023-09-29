using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7_1_5.Tests
{
  [TestClass()]
  public class ProgramTests
  {
    [TestMethod()]
    public void AddContractorTest()
    {
      string customerName = Guid.NewGuid().ToString();
      string contractorName = Guid.NewGuid().ToString();
      string subject = "Subj2";

      Assert.IsNotNull(_context);

      var contractor = Program_7_1_5.AddContractor(_context, contractorName);
      Assert.IsNotNull(contractor);
      var customer = Program_7_1_5.AddCustomer(_context, customerName);
      Assert.IsNotNull(customer);
      var document = Program_7_1_5.AddContract(contractor: contractor, customer: customer, subject: subject);
      Assert.IsNotNull(document);
      Assert.IsTrue(document.Contractor?.Name.Equals(contractorName));
      Assert.IsTrue(document.Customer?.Name.Equals(customerName));
      Assert.IsTrue(document.Subject.Equals(subject));
      _context.SaveChanges();
    }

    [TestMethod()]
    public void AddContractRemoveContractorTest()
    {
      string subject = "Subj2";

      var contractorName = Guid.NewGuid().ToString();

      Assert.IsNotNull(_context);

      var contractor = Program_7_1_5.AddContractor(_context, contractorName);
      Assert.IsNotNull(contractor);
      string customerName = Guid.NewGuid().ToString();
      var customer = Program_7_1_5.AddCustomer(_context, customerName);
      Assert.IsNotNull(customer);
      var document = Program_7_1_5.AddContract(contractor: contractor, customer: customer, subject: subject);
      Assert.IsNotNull(document);
      Assert.IsTrue(document.Contractor?.Name.Equals(contractorName));
      Assert.IsTrue(document.Customer?.Name.Equals(customerName));
      Assert.IsTrue(document.Subject.Equals(subject));
      _context.SaveChanges();

      document.Contractor = null;
      _context.SaveChanges();

      Assert.IsNull(document.Contractor);


      var contractorWithoutContract = _context.Contractor.Any(c => c.Name.Equals(contractorName));
      Assert.IsTrue(contractorWithoutContract,"Contractor is not available");

    }



    private AppDbContext_7_1_5? _context;

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

      var factory = new AppDbContextFactory_7_1_5();
      _context = factory.CreateDbContext(Array.Empty<string>());
      _context.Database.EnsureCreated();
      if (_context == null) { return; }
      _context.Database.BeginTransaction();
    }
  }
}