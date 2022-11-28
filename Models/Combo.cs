using System;
namespace McDonalds.Models
{
  public class Combo
  {
    public int Id { get; set; }
    public string? name { get; set; }

    public float price { get; set; }

  }

  public class ComboRequest
  {
    public string? name { get; set; }
    public float price { get; set; }
    public List<string>? foods { get; set; }
  }

  public class ComboResponse
  {
    public string? name { get; set; }
    public float price { get; set; }
    public List<Food>? foods { get; set; }
  }

}