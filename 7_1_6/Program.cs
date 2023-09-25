using _7_1_6;
using Microsoft.AspNetCore;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services); // calling ConfigureServices method
    var app = builder.Build();
    startup.Configure(app, builder.Environment); // calling Configure method
  }

  public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
}