using McDonalds.Utilities;
using Microsoft.AspNetCore.Mvc;
using McDonalds.Models;
namespace McDonalds.Controllers;

[ApiController]
public class ComboController : Controller
{
  private readonly McDonaldsDBContext _context;

  public ComboController(McDonaldsDBContext context)
  {
    _context = context;
  }

  [HttpGet]
  [Route("api/combo")]
  public async Task<Response<List<ComboResponse>>> GetCombos()
  {
    // triple table join - https://stackoverflow.com/a/26488779
    IQueryable<ComboFoodPair> query =
    from combo in _context.Combo
    join comboItem in _context.ComboItem // join combo with combo item
      on new { id = combo.Id } equals new { id = comboItem.ComboId }
    join food in _context.Food // join combo item with food
      on new { id = comboItem.FoodId } equals new { id = food.Id }
    select new ComboFoodPair { combo = combo, food = food };

    //Iqueryable to list - https://stackoverflow.com/a/755833
    List<ComboFoodPair> tripleJoinResult = query.Select(
      row => new ComboFoodPair { combo = row.combo, food = row.food }
    ).ToList();

    List<ComboResponse> result = Utils.GroupByFood(tripleJoinResult);

    return new(200, "success", result);
  }


  [HttpPost]
  [Route("api/combo")]
  public async Task<Response<ComboResponse>> CreateCombo([FromBody] ComboRequest combo)
  {
    bool comboExists = _context.Combo.Any(c => c.name == combo.name);
    if (comboExists)
    {
      return new(409, $"{combo.name} already exists in the database", null);
    }

    // look for foods in database, throw error if not found
    List<Food> linkedFoods = new List<Food>();
    for (int i = 0; i < combo.foods?.Count; i++)
    {
      string currFood = combo.foods[i];
      var existingFood = _context.Food.FirstOrDefault(f => f.name == currFood);
      if (existingFood == null) return new(404, $"{currFood} does not exist in the database", null);

      linkedFoods.Add(existingFood);
    }

    await _context.Combo.AddAsync(new Combo { name = combo.name, price = combo.price });
    await _context.SaveChangesAsync();

    Combo createdCombo = _context.Combo.FirstOrDefault(c => c.name == combo.name)!;
    int comboId = createdCombo.Id;

    for (int i = 0; i < linkedFoods.Count; i++)
    {
      int currFoodId = linkedFoods[i].Id;
      await _context.ComboItem.AddAsync(new ComboItem { ComboId = comboId, FoodId = currFoodId });
    }
    await _context.SaveChangesAsync();

    ComboResponse result = Utils.createComboResponse(combo.name!, combo.price, linkedFoods);

    return new(200, "ok", result);
  }
}