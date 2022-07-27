namespace BarryTheBaker.Tests;
using Xunit;

public class ApplePieQuantityCalculatorTests {
    [Fact]
    public void GivenExactQuantitiesForOnePie_ReturnsOnePie()
    {
        // Given
        var ingredients = new ApplePieRecipe().Ingredients;
        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        Assert.Equal(1, maxPies.Item1);
        Assert.Equal(1, maxPies.Item2);
    }

    [Fact]
    public void NotEnoughIngredients_ReturnsZeroPies(){
        var ingredients = IngredientList.CreateEmptyList();
        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        Assert.Equal(0, maxPies.Item1);
        Assert.Equal(0, maxPies.Item2);
    }

    [Fact]
    public void GivenExactQuantitiesForOnePieWithCinnamon_ReturnsOnePie()
    {
        // Given
        var ingredients = new ApplePieRecipe().Ingredients;
        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        Assert.Equal(1, maxPies.Item2);
    }

    [Fact]
    public void GivenExactQuantitiesForOnePieWithNoCinnamon_ReturnsOnePieAndZeroCinnamon()
    {
        // Given
        var ingredients = new ApplePieRecipe().Ingredients;
        ingredients[Ingredient.Cinnamon].Quantity = 0;
        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        Assert.Equal(1, maxPies.Item1);
        Assert.Equal(0, maxPies.Item2);
    }

    [Fact]
    public void CalculateLeftOverIngredients_WithExactIngredients_ReturnsZeroLeftovers(){
        var ingredients = new ApplePieRecipe().Ingredients;
        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(0, leftoverIngredients[Ingredient.Apples].Quantity);
        Assert.Equal(0, leftoverIngredients[Ingredient.Butter].Quantity);
        Assert.Equal(0, leftoverIngredients[Ingredient.Cinnamon].Quantity);
        Assert.Equal(0, leftoverIngredients[Ingredient.Flour].Quantity);
        Assert.Equal(0, leftoverIngredients[Ingredient.Sugar].Quantity);
    }

    [Fact]
    public void CalculateLeftOverIngredients_WithExtraIngredients_ReturnsCorrectLeftovers(){
        var applePie = new ApplePieRecipe();
        var ingredients = applePie.Ingredients;
        ingredients[Ingredient.Apples].Quantity += 1;
        ingredients[Ingredient.Butter].Quantity += 1;
        ingredients[Ingredient.Cinnamon].Quantity += 1;
        ingredients[Ingredient.Flour].Quantity += 1;
        ingredients[Ingredient.Sugar].Quantity += 1;

        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(1, leftoverIngredients[Ingredient.Apples].Quantity);
        Assert.Equal(1, leftoverIngredients[Ingredient.Butter].Quantity);
        Assert.Equal(1, leftoverIngredients[Ingredient.Cinnamon].Quantity);
        Assert.Equal(1, leftoverIngredients[Ingredient.Flour].Quantity);
        Assert.Equal(1, leftoverIngredients[Ingredient.Sugar].Quantity);
    }

    [Fact]
    public void CalculateLeftOverIngredients_WithLessThanNeededQuantities_ReturnsCorrectLeftovers(){
        var applePie = new ApplePieRecipe();
        var ingredients = IngredientList.CreateEmptyList();
        ingredients[Ingredient.Apples].Quantity = applePie.Ingredients[Ingredient.Apples].Quantity - 1;
        ingredients[Ingredient.Butter].Quantity = applePie.Ingredients[Ingredient.Butter].Quantity - 1;
        ingredients[Ingredient.Cinnamon].Quantity = applePie.Ingredients[Ingredient.Cinnamon].Quantity - 1;
        ingredients[Ingredient.Flour].Quantity = applePie.Ingredients[Ingredient.Flour].Quantity - 1;
        ingredients[Ingredient.Sugar].Quantity = applePie.Ingredients[Ingredient.Sugar].Quantity - 1;

        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(ingredients[Ingredient.Apples].Quantity, leftoverIngredients[Ingredient.Apples].Quantity);
        Assert.Equal(ingredients[Ingredient.Butter].Quantity, leftoverIngredients[Ingredient.Butter].Quantity);
        Assert.Equal(ingredients[Ingredient.Cinnamon].Quantity, leftoverIngredients[Ingredient.Cinnamon].Quantity);
        Assert.Equal(ingredients[Ingredient.Flour].Quantity, leftoverIngredients[Ingredient.Flour].Quantity);
        Assert.Equal(ingredients[Ingredient.Sugar].Quantity, leftoverIngredients[Ingredient.Sugar].Quantity);
    }
}