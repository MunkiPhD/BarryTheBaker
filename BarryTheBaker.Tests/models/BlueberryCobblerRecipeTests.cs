using BarryTheBaker;

public class BlueberryCobblerRecipeTests {
    [Fact]
    public void BlueberryCobblerRecipe_HasCorrectIngredientQuantities(){
        BlueberryCobblerRecipe recipe = new BlueberryCobblerRecipe();
        var ingredients = recipe.Ingredients;
        Assert.Equal(4, ingredients[Ingredient.Blueberries]);
        Assert.Equal(1, ingredients[Ingredient.LemonZest]);
        Assert.Equal(5, ingredients[Ingredient.ButterTbsp]);
        Assert.Equal(1, ingredients[Ingredient.Flour]);
        Assert.Equal(1, ingredients[Ingredient.Sugar]);
        Assert.Equal(1, ingredients[Ingredient.Milk]);
        Assert.Equal(1, ingredients[Ingredient.Cinnamon]);
    }
}