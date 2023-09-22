using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SampleAPI;

namespace _7_1_5
{
  public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var sqlConnectionObject = new SqlConnectionObject();
      sqlConnectionObject.BuildAnkara();

      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlServer(sqlConnectionObject.GetConnectionString());

      return new AppDbContext(optionsBuilder.Options);
    }
  }
}