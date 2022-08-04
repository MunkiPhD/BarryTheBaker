namespace BarryTheBaker.Tests;
using Xunit;


public class RecipeCreationCalculatorTests {
    [Fact]
    public void GivenExactQuantitiesForOneRecipe_returnsOne(){
        RecipeCreationCalculator calculator = new RecipeCreationCalculator();
        IRecipe recipe = new ApplePieRecipe();
        var ingredientsAvailable = GenerateIngredientListHelper(recipe, 0);
        
        RecipeGenerationResults recipeResults = calculator.MaxQuantity(recipe, ingredientsAvailable);

        Assert.Equal(1, recipeResults.MaxQuantity);
        foreach(var ingredient in recipe.Ingredients){
           RecipeIngredient recipeIngredient = ingredient.Value;
           Assert.Equal(0, recipeResults.RemainingIngredients[recipeIngredient.Ingredient].Quantity);
        }
        
    }

    [Fact]
    public void GivenExtraIngredientsForOneRecipe_ReturnsOneRecipeAndExtraIngredients(){
        RecipeCreationCalculator calculator = new RecipeCreationCalculator();
        IRecipe recipe = new ApplePieRecipe();
        var ingredientsAvailable = GenerateIngredientListHelper(recipe, 1);
    
        RecipeGenerationResults recipeResults = calculator.MaxQuantity(recipe, ingredientsAvailable);

        Assert.Equal(1, recipeResults.MaxQuantity);
        foreach(var ingredient in recipe.Ingredients){
           var recipeIngredient = ingredient.Value;
           Assert.Equal(1, recipeResults.RemainingIngredients[recipeIngredient.Ingredient].Quantity);
        }

    }

    [Fact]
    public void RecipeResults_ReturnsRecipe(){
        RecipeCreationCalculator calculator = new RecipeCreationCalculator();
        var ingredientsAvailable = GenerateIngredientListHelper(new ApplePieRecipe());

        var results = calculator.MaxQuantity(new ApplePieRecipe(), ingredientsAvailable);
        Assert.IsType<ApplePieRecipe>(results.Recipe);
    }

    /// <summary>
    /// Helper method to generate a list of ingredients
    /// </summary>
    /// <param name="recipe"></param>
    /// <param name="additionalQuantity">The number to add or decrement from the quantity</param>
    /// <returns></returns>
    private Dictionary<Ingredient, RecipeIngredient> GenerateIngredientListHelper(IRecipe recipe, int additionalQuantity = 0){
        var ingredientsAvailable = new Dictionary<Ingredient, RecipeIngredient>();
         foreach(var x in recipe.Ingredients){
            var ingredient = x.Value;
            ingredient.Quantity += additionalQuantity;
            ingredientsAvailable.Add(ingredient.Ingredient, new RecipeIngredient(ingredient.Ingredient, ingredient.Quantity + additionalQuantity, ingredient.Measurement));
        }

        return ingredientsAvailable;
    }
}