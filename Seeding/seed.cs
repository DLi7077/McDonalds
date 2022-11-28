using System.Text.Json;
using McDonalds.Models;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Seeding;

public static class Seeder
{
  public static async Task ClearTable(McDonaldsDBContext _context)
  {
    // clear every table
    _context.Database.ExecuteSqlRaw("DELETE FROM ComboItem");
    _context.Database.ExecuteSqlRaw("DELETE FROM Combo");
    _context.Database.ExecuteSqlRaw("DELETE FROM Food");
    Console.WriteLine("Cleared Food Table");
    await _context.SaveChangesAsync();
  }

  public static List<Food> LoadJson(string fileName)
  {
    using (StreamReader r = new StreamReader(fileName))
    {
      string json = r.ReadToEnd();
      List<Food> items = JsonSerializer.Deserialize<List<Food>>(json)!;
      return items;
    }
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
}
