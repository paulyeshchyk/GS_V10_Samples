using _7_1.Entities;
using _7_1_2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _7_1_6.Controllers
{


  [ApiController]
  [Route("[controller]")]
  public class TestController : ControllerBase
  {
    private AppDbContext_7_1_2 _dbContext = new AppDbContext_7_1_2();

    [HttpGet]
    public IEnumerable<RefContractor> Get()
    {
      return _dbContext.Contractor.ToList();
    }


  }
}
