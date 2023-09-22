using _7_1.SampleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace SampleAPI.Tests;

[TestClass]
public class DocumentDisposableClassTests
{
  [TestMethod]
  public void Test_7_1_1_a()
  {
    var sample = new DocumentClass { Name = "Name1" };
    Assert.IsNotNull(sample);

    using var sampleDisposable = new DocumentDisposableClass { Name = "Name1" };
    Assert.IsNotNull(sampleDisposable);
  }

  [TestMethod]
  public void Test_7_1_2_b()
  {
    using var sampleDisposable = new DocumentDisposableClass { Name = "Name1" };
    Assert.AreEqual("Name1", sampleDisposable.Name);

    sampleDisposable.Name = "Name2";
    Assert.AreEqual("Name2", sampleDisposable.Name);
  }

  [TestMethod]
  public void Test_7_1_2_c()
  {
    var sampleDisposable = new DocumentDisposableClass { Name = "Name1" };
    sampleDisposable.Dispose();

    var isDisposed = false;
    var privateInt = sampleDisposable?.GetType().GetProperty("IsDisposed",
      BindingFlags.Instance | BindingFlags.Public);
    if (privateInt != null) isDisposed = (bool)privateInt.GetValue(sampleDisposable);

    Assert.IsTrue(isDisposed);
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