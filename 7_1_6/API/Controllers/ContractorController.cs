using _7_1.Entities;
using _7_1_2;
using Microsoft.AspNetCore.Mvc;

namespace _7_1_6.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //конечный путь https://localhost:7175/api/Contractor
  public class ContractorController : ControllerBase
  {
    private AppDbContext_7_1_2 _dbContext = new AppDbContext_7_1_2();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RefContractor>>> GetContractorList()
    {
      return await Task.FromResult(_dbContext.Contractor.ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RefContractor>> GetContractor(int id)
    {
      var result = await _dbContext.Contractor.FindAsync(id);
      if (result == null)
      {
        return NotFound();
      }
      return result;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteContractor(int id)
    {
      var contractor = await _dbContext.Contractor.FindAsync(id);
      if (contractor == null)
      {
        return NotFound();
      }
      _dbContext.Contractor.Remove(contractor);
      await _dbContext.SaveChangesAsync();
      return 0;
    }


    [HttpPost]
    public async Task<ActionResult<RefContractor>> PostContractor(RefContractor contractor)
    {
      _dbContext.Contractor.Add(contractor);
      await _dbContext.SaveChangesAsync();
      return CreatedAtAction(nameof(GetContractor), new { Id = contractor.Id, Name = contractor.Name }, contractor);
    }


  }
}
