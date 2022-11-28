using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Models;

[ApiController]
public class FoodController : Controller
{
  private readonly McDonaldsDBContext _context;

  public FoodController(McDonaldsDBContext context)
  {
    _context = context;
  }

  // retrieving string params https://stackoverflow.com/a/41577487
  [HttpGet]
  [Route("api/food/")]
  public async Task<Response<IEnumerable<Food>>> GetFoods()
  {
    string sortBy = HttpContext.Request.Query["sortBy"].ToString();
    string sortDir = HttpContext.Request.Query["sortDir"].ToString();

    bool descending = sortDir == "desc";

    IQueryable<Food> query = from food in _context.Food select food;
    if (sortBy.Length == 0) return new(200, "ok", query);
    if (descending)
    {
      query = query.OrderByDescending(p => EF.Property<object>(p, sortBy));
    }
    else
    {
      query = query.OrderBy(p => EF.Property<object>(p, sortBy));
    }

    return new(200, "success", query);
  }

  // error response https://stackoverflow.com/a/21682621
  [HttpPost]
  [Route("api/food")]
  public async Task<Response<Food>> CreateFood([FromBody] Food food)
  {
    // see if food already exists
    bool foodExists = _context.Food.Any(f => f.name == food.name);

    if (foodExists)
    {
      string duplicateError = $"{food.name} already exists in the database";
      return new(409, duplicateError, null);
    }

    var query = from calories in _context.Set<Food>() select calories;

    await _context.Food.AddAsync(food);
    await _context.SaveChangesAsync();

    return new(200, "success", food);
  }

  [HttpPost]
  [Route("api/foods")]
  // https://stackoverflow.com/questions/18667633/how-can-i-use-async-with-foreach
  public async Task<Response<IEnumerable<Food>>> CreateFoods([FromBody] List<Food> foods)
  {
    for (int i = 0; i < foods.Count; i++)
    {
      bool foodExists = _context.Food.Any(f => f.name == foods[i].name);
      if (foodExists)
      {
        string duplicateError = $"{foods[i].name} already exists in the database";
        return new(409, duplicateError, null);
      }
      await _context.Food.AddAsync(foods[i]);
    }
    await _context.SaveChangesAsync();

    return new(200, "success", await _context.Food.ToListAsync());
  }

  // Update a food in the table
  // error response https://stackoverflow.com/a/21682621
  [HttpPut]
  [Route("api/food")]
  public async Task<ActionResult<Food>> UpdateFood([FromBody] Food food)
  {
    // see if food already exists
    var existingFood = _context.Food.FirstOrDefault(f => f.name == food.name);

    if (existingFood == null)
    {
      String doesNotExistError = $"{food.name} does not exist in the database";
      HttpContext.Response.StatusCode = 404;
      return Json(new { error = doesNotExistError });
    }

    existingFood.price = food.price;
    existingFood.calories = food.calories;
    existingFood.protein = food.protein;
    existingFood.carbs = food.carbs;
    existingFood.sodium = food.sodium;
    existingFood.sugar = food.sugar;
    existingFood.fat = food.fat;

    await _context.SaveChangesAsync();

    return existingFood;
  }
}