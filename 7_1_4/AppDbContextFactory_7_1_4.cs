using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SampleAPI;

namespace _7_1_4
{
  public class AppDbContextFactory_7_1_4 : IDesignTimeDbContextFactory<AppDbContext_7_1_4>
  {
    public AppDbContext_7_1_4 CreateDbContext(string[] args)
    {
      var sqlConnectionObject = new SampleAPI.SqlConnectionObject();
      sqlConnectionObject.BuildAnkara();

      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext_7_1_4>();
      optionsBuilder.UseSqlServer(sqlConnectionObject.GetConnectionString());

      return new AppDbContext_7_1_4(optionsBuilder.Options);
    }
  }
}