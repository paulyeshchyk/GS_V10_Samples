using _7_1_6.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _7_1_6.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TestController : ControllerBase
  {
    [HttpGet(Name = "GetTest")]
    public IEnumerable<int> Get()
    {
      return new[] { 1, 2, 3 };
    }
  }
}
