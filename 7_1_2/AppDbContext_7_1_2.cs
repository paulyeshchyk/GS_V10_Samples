using _7_1.Entities;
using Microsoft.EntityFrameworkCore;
using SampleAPI;

namespace _7_1_2
{
  public class AppDbContext_7_1_2 : DbContext
  {
    public AppDbContext_7_1_2()
    {
      //Database.EnsureCreated();
    }

    public AppDbContext_7_1_2(DbContextOptions<AppDbContext_7_1_2> options) : base(options)
    {
    }

    public DbSet<RefContractor> Contractor { get; set; }
    public DbSet<RefCustomer> Customer { get; set; }
    public DbSet<DocCustomerContract> CustomerContract { get; set; }
    public DbSet<DocCustomerContractInvoice> CustomerContractInvoces { get; set; }
    public DbSet<DocEmployeeContract> EmployeeContract { get; set; }
    public DbSet<DocEmployeeContractAddendum> EmployeeContractAddendum { get; set; }
    public DbSet<RefEmployee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var sqlConnectionObject = new SqlConnectionObject();
      sqlConnectionObject.BuildAnkara();

      var connectionString = sqlConnectionObject.GetConnectionString();
      if (!optionsBuilder.IsConfigured)
      {
        if (null != connectionString)
        {
          optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
          //.LogTo(Console.WriteLine);
        }
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}