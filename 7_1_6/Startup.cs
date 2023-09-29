namespace _7_1_6
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration
    {
      get;
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseCors(options => 
        options.WithOrigins("*")//http://localhost:4200/
        .AllowAnyMethod()
        .AllowAnyHeader()
        );

      app.UseHttpsRedirection();

      //app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
    }

    // Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(c => { c.EnableAnnotations(); });
    }
  }
}