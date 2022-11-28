using System.Text.Json;
using McDonalds.Models;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Seeding;

public static class JsonParser<Any>
{
  public static List<Any> LoadJson(string fileName)
  {
    using (StreamReader r = new StreamReader(fileName))
    {
      string json = r.ReadToEnd();
      List<Any> items = JsonSerializer.Deserialize<List<Any>>(json)!;
      return items;
    }
  }
}
public static class Seeder
{
  public static async Task ClearTable(McDonaldsDBContext _context)
  {
    // clear every table
    _context.Database.ExecuteSqlRaw("DELETE FROM ComboItem");
    _context.Database.ExecuteSqlRaw("DELETE FROM Combo");
    _context.Database.ExecuteSqlRaw("DELETE FROM Food");

    await _context.SaveChangesAsync();
  }


  public static async Task SeedFoods(McDonaldsDBContext _context, List<Food> foods)
  {
    for (int i = 0; i < foods.Count; i++)
    {
      bool foodExists = _context.Food.Any(f => f.name == foods[i].name);
      if (foodExists)
      {
        Console.WriteLine($"{foods[i].name} already exists, skipping.");
        continue;
      }
      await _context.Food.AddAsync(foods[i]);
    }
    await _context.SaveChangesAsync();
  }

  public static async Task SeedMeals(McDonaldsDBContext _context, List<ComboRequest> combos)
  {
    for (int iteration = 0; iteration < combos.Count; iteration++)
    {
      ComboRequest combo = combos[iteration];

      bool comboExists = _context.Combo.Any(c => c.name == combo.name);
      if (comboExists)
      {
        Console.WriteLine($"{combo.name} already exists, skipping.");
        continue;
      }
      // look for foods in database, throw error if not found
      List<Food> linkedFoods = new List<Food>();
      bool conflict = false;
      for (int i = 0; i < combo.foods?.Count; i++)
      {
        string currFood = combo.foods[i];
        var existingFood = _context.Food.FirstOrDefault(f => f.name == currFood);
        if (existingFood == null)
        {
          Console.WriteLine($"{currFood} does not exist in the database");
          conflict = true;
          break;
        }
        linkedFoods.Add(existingFood);
      }
      if (conflict) continue;

      await _context.Combo.AddAsync(new Combo { name = combo.name, price = combo.price });
      await _context.SaveChangesAsync();

      Combo createdCombo = _context.Combo.FirstOrDefault(c => c.name == combo.name)!;
      int comboId = createdCombo.Id;

      for (int i = 0; i < linkedFoods.Count; i++)
      {
        int currFoodId = linkedFoods[i].Id;
        await _context.ComboItem.AddAsync(new ComboItem { ComboId = comboId, FoodId = currFoodId });
      }
    }
    await _context.SaveChangesAsync();
  }

}
