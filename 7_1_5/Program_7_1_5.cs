using _7_1.Entities;

namespace _7_1_5
{
  public static class Program_7_1_5
  {
    public static DocCustomerContract AddContract(RefContractor contractor, RefCustomer customer,
      string? subject = null)
    {
      var contract = new DocCustomerContract
      {
        Contractor = contractor,
        Customer = customer,
        Subject = subject ?? "Subject1"
      };
      return contract;
    }

    public static DocCustomerContract AddContract(AppDbContext_7_1_5 context715, string contractorName, string customerName, string subject)
    {
      var contractor = AddContractor(context715, contractorName);
      var customer = AddCustomer(context715, customerName);
      return AddContract(contractor, customer, subject);
    }

    public static RefContractor AddContractor(AppDbContext_7_1_5 context715, string? contractorName = null)
    {
      var contractor = new RefContractor
      {
        Name = contractorName ?? "Contractor1"
      };
      context715.Contractor.Add(contractor);
      return contractor;
    }

    public static RefCustomer AddCustomer(AppDbContext_7_1_5 context715, string? customerName = null)
    {
      var customer = new RefCustomer
      {
        Name = customerName ?? "Customer1"
      };
      context715.Customer.Add(customer);
      return customer;
    }

    [STAThread]
    private static void Main(string[] args)
    {
      using var context = new AppDbContext_7_1_5();
      context.Database.EnsureCreated();
      var document = AddContract(context715: context, contractorName: "Contractor1", customerName: "Customer1", subject: "Subject1");
      Console.WriteLine($"Был создан контракт {document.Subject} между заказчиком: {document.Customer?.Name} и подрядчиком: {document.Contractor?.Name}");
      Console.ReadKey();
      context.SaveChanges();
    }
  }
}