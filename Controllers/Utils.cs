using McDonalds.Models;
namespace McDonalds.Utilities;

public static class Utils
{
  // helper function to simulate groupby
  public static List<AllCombosResponse> GroupByFood(List<ComboFoodPair> comboFoodPairs)
  {
    Dictionary<int, int> indexMapping = new Dictionary<int, int>();
    List<AllCombosResponse> result = new List<AllCombosResponse>();

    int rows = 0;
    comboFoodPairs.ForEach(pair =>
    {
      Combo currCombo = pair.combo!;
      Food currFood = pair.food!;

      if (indexMapping.ContainsKey(currCombo.Id))
      {
        int comboIndex = indexMapping[currCombo.Id];
        result[comboIndex].foods!.Add(currFood);
      }

      else
      {
        result.Add(new AllCombosResponse { combo = currCombo, foods = new List<Food> { currFood } });
        indexMapping[currCombo.Id] = rows++;
      }

    });

    return result;
  }
}