using BarryTheBaker;

public class BlueberryCobblerRecipeTests {
    [Fact]
    public void BlueberryCobblerRecipe_HasCorrectIngredientQuantities(){
        BlueberryCobblerRecipe recipe = new BlueberryCobblerRecipe();
        Assert.Equal(4, recipe.Ingredients[Ingredient.Blueberries].Quantity);
        Assert.Equal(4, recipe.Ingredients[Ingredient.Blueberries].Quantity);
        Assert.Equal(1, recipe.Ingredients[Ingredient.LemonZest].Quantity);
        Assert.Equal(5, recipe.Ingredients[Ingredient.Butter].Quantity);
        Assert.Equal(1, recipe.Ingredients[Ingredient.Flour].Quantity);
        Assert.Equal(1, recipe.Ingredients[Ingredient.Sugar].Quantity);
        Assert.Equal(1, recipe.Ingredients[Ingredient.Milk].Quantity);
        Assert.Equal(1, recipe.Ingredients[Ingredient.Cinnamon].Quantity);
    }

    [Fact]
    public void ReturnsTheCorrectRecipeName(){
        var recipe = new BlueberryCobblerRecipe();
        Assert.Equal("Blueberry Cobbler", recipe.Name);
    }
}