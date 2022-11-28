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

}