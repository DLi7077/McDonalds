using Microsoft.AspNetCore.Mvc;
namespace McDonalds.Controllers;

[ApiController]

public class McDonaldsController : ControllerBase
{
  private readonly McDonaldsDBContext _context;

  public McDonaldsController(McDonaldsDBContext context)
  {
    _context = context;
  }

  // GET: customers
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Customer>>> getCustomers()
  {
    return await _context.Customers.ToListAsync();
  }

}