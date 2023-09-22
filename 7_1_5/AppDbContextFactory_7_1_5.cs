using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SampleAPI;

namespace _7_1_5
{
  public class AppDbContextFactory_7_1_5 : IDesignTimeDbContextFactory<AppDbContext_7_1_5>
  {
    public AppDbContext_7_1_5 CreateDbContext(string[] args)
    {
      var sqlConnectionObject = new SqlConnectionObject();
      sqlConnectionObject.BuildAnkara();

      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext_7_1_5>();
      optionsBuilder.UseSqlServer(sqlConnectionObject.GetConnectionString());

      return new AppDbContext_7_1_5(optionsBuilder.Options);
    }
  }
}