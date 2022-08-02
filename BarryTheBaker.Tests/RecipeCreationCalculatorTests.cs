namespace BarryTheBaker.Tests;
using Xunit;


public class RecipeCreationCalculatorTests {
    [Fact]
    public void GivenExactQuantitiesForOneRecipe_returnsOne(){
        RecipeCreationCalculator calculator = new RecipeCreationCalculator();
        IRecipe recipe = new ApplePieRecipe();
        var ingredientsAvailable = new Dictionary<Ingredient, RecipeIngredient>();
        foreach(var x in recipe.Ingredients){
            ingredientsAvailable.Add(x.Key, x.Value);
        }
        
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
        var ingredientsAvailable = new Dictionary<Ingredient, RecipeIngredient>();
        foreach(var x in recipe.Ingredients){
            var ingredient = x.Value;
            ingredient.Quantity += 1;
            ingredientsAvailable.Add(ingredient.Ingredient, new RecipeIngredient(ingredient.Ingredient, ingredient.Quantity + 1, ingredient.Measurement));
        }
    
        RecipeGenerationResults recipeResults = calculator.MaxQuantity(recipe, ingredientsAvailable);

        Assert.Equal(1, recipeResults.MaxQuantity);
        foreach(var ingredient in recipe.Ingredients){
           var recipeIngredient = ingredient.Value;
           Assert.Equal(1, recipeResults.RemainingIngredients[recipeIngredient.Ingredient].Quantity);
        }

    }
}