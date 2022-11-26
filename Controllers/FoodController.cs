using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace McDonalds.Models;

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
  [Route("api/food/")]
  public async Task<ActionResult<IEnumerable<Food>>> getFood()
  {
    string sortBy = HttpContext.Request.Query["sortBy"].ToString();
    string sortDir = HttpContext.Request.Query["sortDir"].ToString();

    bool descending = sortDir == "desc";

    IQueryable<Food> query = from food in _context.Food select food;
    if (sortBy.Length == 0) return Ok(query);
    if (descending)
    {
      query = query.OrderByDescending(p => EF.Property<object>(p, sortBy));
    }
    else
    {
      query = query.OrderBy(p => EF.Property<object>(p, sortBy));
    }

    return Ok(query);
  }


  [HttpPost]
  [Route("api/food")]
  public async Task<ActionResult<IEnumerable<Food>>> createFood([FromBody] Food food)
  {
    var query = from calories in _context.Set<Food>()
                select calories;

    await _context.Food.AddAsync(food);
    await _context.SaveChangesAsync();

    return await _context.Food.ToListAsync();
  }

  [HttpPost]
  [Route("api/foods")]
  // https://stackoverflow.com/questions/18667633/how-can-i-use-async-with-foreach
  public async Task<ActionResult<IEnumerable<Food>>> createFoods([FromBody] List<Food> foods)
  {
    for (int i = 0; i < foods.Count; i++)
    {
      await _context.Food.AddAsync(foods[i]);
    }
    await _context.SaveChangesAsync();



    return await _context.Food.ToListAsync();
  }

}