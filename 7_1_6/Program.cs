using _7_1_6;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    /*
    builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        // указывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = true,
        // строка, представляющая издателя
        ValidIssuer = AuthOptions.ISSUER,
        // будет ли валидироваться потребитель токена
        ValidateAudience = true,
        // установка потребителя токена
        ValidAudience = AuthOptions.AUDIENCE,
        // будет ли валидироваться время существования
        ValidateLifetime = true,
        // установка ключа безопасности
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
      };
    });
    builder.Services.AddAuthorization();
    */
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services); // calling ConfigureServices method
    var app = builder.Build();
    startup.Configure(app, builder.Environment); // calling Configure method
  }

  public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
}