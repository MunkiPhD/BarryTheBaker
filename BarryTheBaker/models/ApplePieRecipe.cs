using BarryTheBaker;

public class ApplePieRecipe {
    public readonly IDictionary<Ingredient, int> Ingredients;

    public ApplePieRecipe(){
        Ingredients = new Dictionary<Ingredient, int>();
        Ingredients.Add(Ingredient.Apples, 2);
        Ingredients.Add(Ingredient.Sugar, 2);
        Ingredients.Add(Ingredient.Flour, 1);
        Ingredients.Add(Ingredient.Cinnamon, 1);
        Ingredients.Add(Ingredient.Butter, 6);
    }
}

