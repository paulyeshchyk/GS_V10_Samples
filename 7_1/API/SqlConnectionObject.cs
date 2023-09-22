using System.Collections;

namespace SampleAPI
{
  public class SqlConnectionObject
  {
    public string? Datasource { get; set; }
    public string? InitialCatalog { get; set; }
    public string? UserId { get; set; }
    public string? Password { get; set; }

    public string? TrustServerCertificate { get; set; }

    // "Data Source=localhost;Initial Catalog=ankara;User ID=ankaraUser;Password=user123!"
    public string? GetConnectionString()
    {
      var result = new ArrayList();
      result.AddKvo("Data Source", this.Datasource);
      result.AddKvo("Initial Catalog", this.InitialCatalog);
      result.AddKvo("User ID", this.UserId);
      result.AddKvo("Password", this.Password);
      result.AddKvo("TrustServerCertificate", this.TrustServerCertificate);
      return result.Join(';');
    }
  }
}