public class BlueberryCobblerRecipe:IRecipe {
    public IDictionary<Ingredient, RecipeIngredient> Ingredients {get;}

    public BlueberryCobblerRecipe(){
        // setup all the ingredients for this
        Ingredients = new Dictionary<Ingredient, RecipeIngredient>();
        Ingredients.Add(Ingredient.Blueberries, new RecipeIngredient(Ingredient.Blueberries, 4, MeasurementType.Cups));
        Ingredients.Add(Ingredient.LemonZest, new RecipeIngredient(Ingredient.LemonZest, 1, MeasurementType.Unit));
        Ingredients.Add(Ingredient.Butter, new RecipeIngredient(Ingredient.Butter, 5, MeasurementType.Tbsp));
        Ingredients.Add(Ingredient.Flour, new RecipeIngredient(Ingredient.Flour, 1, MeasurementType.Cups));
        Ingredients.Add(Ingredient.Sugar, new RecipeIngredient(Ingredient.Sugar, 1, MeasurementType.Cups));
        Ingredients.Add(Ingredient.Milk, new RecipeIngredient(Ingredient.Milk, 1, MeasurementType.Cups));
        Ingredients.Add(Ingredient.Cinnamon, new RecipeIngredient(Ingredient.Cinnamon, 1, MeasurementType.Tsp));
    }
}