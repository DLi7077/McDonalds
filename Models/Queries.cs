using System;
namespace McDonalds.Models
{
  public class ComboFoodPair
  {
    public Combo? combo { get; set; }
    public Food? food { get; set; }
  }

  public class AllCombosResponse
  {
    public Combo? combo { get; set; }
    public List<Food>? foods { get; set; }
  }

  public class ComboResponse
  {
    public string? name { get; set; }
    public float price { get; set; }
    public int calories { get; set; }
    public int protein { get; set; }
    public int carbs { get; set; }
    public int sodium { get; set; }
    public int sugar { get; set; }
    public int fat { get; set; }
    public List<Food>? foods { get; set; }
  }
}