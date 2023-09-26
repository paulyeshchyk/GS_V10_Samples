using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace _7_1_6
{
  public class Startup
  {

    public IConfiguration Configuration
    {
      get;
    }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    // Use this method to add services to the container.  
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(c => { c.EnableAnnotations();});

    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseCors(options =>options.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        );

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();

      app.Run();
    }
  }
}
