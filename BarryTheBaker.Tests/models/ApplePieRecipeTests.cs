namespace BarryTheBaker.Tests;
using Xunit;

public class ApplePieRecipeTests
{
    [Fact]
    public void ApplePieRecipe_HasIngredients()
    {
        var recipe = new ApplePieRecipe();
        Assert.NotNull(recipe.Ingredients);
    }

    [Fact]
    public void ApplePieRecipe_HasCorrectIngredientCounts(){
        var applePieRecipe = new ApplePieRecipe();
        var ingredients = applePieRecipe.Ingredients;
        Assert.Equal(2, ingredients[Ingredient.Apples]);
        Assert.Equal(2, ingredients[Ingredient.Sugar]);
        Assert.Equal(1, ingredients[Ingredient.Flour]);
        Assert.Equal(1, ingredients[Ingredient.Cinnamon]);
        Assert.Equal(6, ingredients[Ingredient.ButterTbsp]);
    }
}