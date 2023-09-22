using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7_1_3.Tests
{
  [TestClass()]
  public class ProgramTests
  {
    [TestMethod()]
    public void AddDocumentContractorTest()
    {
      var document = Program_7_1_3.AddDocument();
      Assert.IsNotNull(document);
      Assert.IsFalse(document.Name.IsNullOrEmpty());

      var contractor = Program_7_1_3.AddContractor();
      Assert.IsNotNull(contractor);
      Assert.IsTrue(contractor.Name is "Contractor1");

      var documentContractor = Program_7_1_3.AddDocumentContractor(document: document, contractor: contractor);
      Assert.IsNotNull(documentContractor);
      Assert.IsTrue(documentContractor.IsValid);
    }

    [TestMethod()]
    public void AddDocumentContractorWithoutContractorTest()
    {
      var document = Program_7_1_3.AddDocument();
      Assert.IsNotNull(document);
      var documentContractor = Program_7_1_3.AddDocumentContractor(document: document, contractor: null);
      Assert.IsNull(documentContractor);
    }

    [TestMethod()]
    public void AddDocumentContractorWithoutDocumentTest()
    {
      var contractor = Program_7_1_3.AddContractor();
      Assert.IsNotNull(contractor);
      var documentContractor = Program_7_1_3.AddDocumentContractor(document: null, contractor: contractor);
      Assert.IsNull(documentContractor);
    }

    [TestMethod()]
    public void AddDocumentContractorWithoutDocumentAndWithoutContractorTest()
    {
      var documentContractor = Program_7_1_3.AddDocumentContractor(document: null, contractor: null);
      Assert.IsNull(documentContractor);
    }

    [TestMethod()]
    public void AddDocumentContractorTestThenBreakLinks()
    {
      var document = Program_7_1_3.AddDocument();
      Assert.IsNotNull(document);
      Assert.IsFalse(document.Name.IsNullOrEmpty());

      var contractor = Program_7_1_3.AddContractor();
      Assert.IsNotNull(contractor);
      Assert.IsTrue(contractor.Name is "Contractor1");

      var documentContractor = Program_7_1_3.AddDocumentContractor(document: document, contractor: contractor);
      Assert.IsNotNull(documentContractor);
      Assert.IsTrue(documentContractor.IsValid);

      documentContractor.ContractorLink = null;
      Assert.IsFalse(documentContractor?.IsValid);

      documentContractor.DocumentLink = null;
      Assert.IsFalse(documentContractor?.IsValid);
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    [TestInitialize]
    public void TestInitialize()
    {
    }
  }
}