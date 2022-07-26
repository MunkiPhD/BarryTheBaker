namespace BarryTheBaker.Tests;
using Xunit;

public class UnitTest1
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
        Assert.Equal(2, applePieRecipe.Ingredients.Apples);
        Assert.Equal(2, applePieRecipe.Ingredients.Sugar);
        Assert.Equal(1, applePieRecipe.Ingredients.Flour);
        Assert.Equal(1, applePieRecipe.Ingredients.Cinnamon);
        Assert.Equal(6, applePieRecipe.Ingredients.Butter);
    }
}