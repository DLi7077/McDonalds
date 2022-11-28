using McDonalds.Models;
namespace McDonalds.Utilities;

public static class Utils
{
  public static ComboResponse createComboResponse(string name, float price, List<Food> foods)
  {
    ComboResponse result = new ComboResponse { name = name, price = price, foods = foods };
    foods.ForEach(food =>
    {
      result.calories += food.calories;
      result.protein += food.protein;
      result.carbs += food.carbs;
      result.sodium += food.sodium;
      result.sugar += food.sugar;
      result.fat += food.fat;
    });

    return result;
  }
  // helper function to simulate groupby
  public static List<ComboResponse> GroupByFood(List<ComboFoodPair> comboFoodPairs)
  {
    Dictionary<int, int> indexMapping = new Dictionary<int, int>();
    List<ComboResponse> result = new List<ComboResponse>();

    int rows = 0;
    comboFoodPairs.ForEach(pair =>
    {
      Combo currCombo = pair.combo!;
      Food currFood = pair.food!;

      if (indexMapping.ContainsKey(currCombo.Id))
      {
        int comboIndex = indexMapping[currCombo.Id];
        result[comboIndex].foods!.Add(currFood);
        result[comboIndex].calories += currFood.calories;
        result[comboIndex].protein += currFood.protein;
        result[comboIndex].carbs += currFood.carbs;
        result[comboIndex].sodium += currFood.sodium;
        result[comboIndex].sugar += currFood.sugar;
        result[comboIndex].fat += currFood.fat;
      }

      else
      {
        result.Add(createComboResponse(currCombo.name!, currCombo.price, new List<Food> { currFood }));
        indexMapping[currCombo.Id] = rows++;
      }

    });

    return result;
  }
}