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
        // ���������, ����� �� �������������� �������� ��� ��������� ������
        ValidateIssuer = true,
        // ������, �������������� ��������
        ValidIssuer = AuthOptions.ISSUER,
        // ����� �� �������������� ����������� ������
        ValidateAudience = true,
        // ��������� ����������� ������
        ValidAudience = AuthOptions.AUDIENCE,
        // ����� �� �������������� ����� �������������
        ValidateLifetime = true,
        // ��������� ����� ������������
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // ��������� ����� ������������
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