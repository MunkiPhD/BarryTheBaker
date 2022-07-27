using BarryTheBaker;

public class ApplePieRecipe:IRecipe {
    public IDictionary<Ingredient, RecipeIngredient> Ingredients {get;}

    public ApplePieRecipe(){
        Ingredients = new Dictionary<Ingredient, RecipeIngredient>();
        Ingredients.Add(Ingredient.Apples, new RecipeIngredient(Ingredient.Apples, 2, MeasurementType.Unit));
        Ingredients.Add(Ingredient.Sugar, new RecipeIngredient(Ingredient.Sugar, 2, MeasurementType.Unit));
        Ingredients.Add(Ingredient.Flour, new RecipeIngredient(Ingredient.Flour, 1, MeasurementType.Unit));
        Ingredients.Add(Ingredient.Cinnamon, new RecipeIngredient(Ingredient.Cinnamon, 1, MeasurementType.Unit));
        Ingredients.Add(Ingredient.Butter, new RecipeIngredient(Ingredient.Butter, 6, MeasurementType.Unit));
    }
}

