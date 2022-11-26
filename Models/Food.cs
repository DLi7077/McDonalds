using System;
namespace McDonalds.Models
{
  public class Food
  {
    public int Id { get; set; }
    public string? name { get; set; }
    public float price { get; set; }
    public int calories { get; set; }
    public int protein { get; set; }
    public int carbs { get; set; }
    public int sodium { get; set; }
    public int sugar { get; set; }
    public int fat { get; set; }
  }
}