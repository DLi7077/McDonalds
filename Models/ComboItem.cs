using System;
namespace McDonalds.Models
{
  // linker table for food to combo
  public class ComboItem
  {
    public int Id { get; set; }
    public int ComboId { get; set; }

    public int FoodId { get; set; }
  }
}