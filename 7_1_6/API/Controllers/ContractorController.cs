using _7_1.Entities;
using _7_1_2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _7_1_6.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //конечный путь https://localhost:7175/api/Contractor
  public class ContractorController : ControllerBase
  {
    private readonly AppDbContext_7_1_2 _dbContext = new();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RefContractor>>> GetContractorList()
    {
      return await Task.FromResult(_dbContext.Contractor.ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RefContractor>> GetContractor(Guid id)
    {
      var result = await _dbContext.Contractor.FindAsync(id);
      return result == null ? NotFound() : new ActionResult<RefContractor>(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteContractor(Guid id)
    {
      var contractor = await _dbContext.Contractor.FindAsync(id);
      if (contractor == null)
      {
        return NotFound();
      }
      _dbContext.Contractor.Remove(contractor);
      await _dbContext.SaveChangesAsync();
      return new ActionResult<Guid>(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<RefContractor>> Put(Guid id, [FromBody] RefContractor contractor)
    {

      var existing = await _dbContext.Contractor.FindAsync(id);
      if (existing == null)
      {
        return NotFound();
      }

      existing.Address = contractor.Address;
      existing.Name = contractor.Name;
      _dbContext.Entry(existing).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
      return new ActionResult<RefContractor>(existing);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> PostContractor(RefContractor contractor)
    {
      _dbContext.Contractor.Add(contractor);
      await _dbContext.SaveChangesAsync();
      return new ActionResult<Guid>(contractor.Id);
    }

  }
}
