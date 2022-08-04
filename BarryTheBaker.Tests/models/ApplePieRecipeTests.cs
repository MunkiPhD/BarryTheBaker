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
    public void ReturnsTheCorrectRecipeName(){
        var recipe = new ApplePieRecipe();
        Assert.Equal("Apple Pie", recipe.Name);
    }

    [Fact]
    public void ApplePieRecipe_HasCorrectIngredientCounts(){
        var applePieRecipe = new ApplePieRecipe();
        var ingredients = applePieRecipe.Ingredients;
        Assert.Equal(2, ingredients[Ingredient.Apples].Quantity);
        Assert.Equal(2, ingredients[Ingredient.Sugar].Quantity);
        Assert.Equal(1, ingredients[Ingredient.Flour].Quantity);
        Assert.Equal(1, ingredients[Ingredient.Cinnamon].Quantity);
        Assert.Equal(6, ingredients[Ingredient.Butter].Quantity);
    }
}