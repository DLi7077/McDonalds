using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Models;

[ApiController]
[Route("api/McDonalds")]
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