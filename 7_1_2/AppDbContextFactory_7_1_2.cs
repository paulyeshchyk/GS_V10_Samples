using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SampleAPI;

namespace _7_1_2
{
  public class AppDbContextFactory_7_1_2 : IDesignTimeDbContextFactory<AppDbContext_7_1_2>
  {
    public AppDbContext_7_1_2 CreateDbContext(string[] args)
    {
      var sqlConnectionObject = new SampleAPI.SqlConnectionObject();
      sqlConnectionObject.BuildAnkara();

      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext_7_1_2>();
      optionsBuilder.UseSqlServer(sqlConnectionObject.GetConnectionString());

      return new AppDbContext_7_1_2(optionsBuilder.Options);
    }
  }
}