using Microsoft.Data.SqlClient;

namespace SampleAPI
{
  public static class SqlConnectionFactory
  {
    public static void BuildAnkara(this SqlConnectionObject connectionObject)
    {
      connectionObject.Datasource = "localhost";
      connectionObject.InitialCatalog = "ankara_py";
      connectionObject.UserId = "ankaraUser";
      connectionObject.Password = "user123!";
      connectionObject.TrustServerCertificate = "True";
    }
  }

  public static class Ankara
  {
    public static SqlConnection Connection()
    {
      var connectionObject = new SqlConnectionObject();
      connectionObject.BuildAnkara();
      return new SqlConnection(connectionObject.GetConnectionString());
    }
  }
}