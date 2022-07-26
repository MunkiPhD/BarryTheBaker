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
        var ingredients = new ApplePieIngredients();
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
        ingredients.Cinnamon = 0;
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
        ApplePieIngredients leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(0, leftoverIngredients.Apples);
        Assert.Equal(0, leftoverIngredients.Butter);
        Assert.Equal(0, leftoverIngredients.Cinnamon);
        Assert.Equal(0, leftoverIngredients.Flour);
        Assert.Equal(0, leftoverIngredients.Sugar);
    }

    [Fact]
    public void CalculateLeftOverIngredients_WithExtraIngredients_ReturnsCorrectLeftovers(){
        var applePie = new ApplePieRecipe();
        var ingredients = applePie.Ingredients;
        ingredients.Apples += 1;
        ingredients.Butter += 1;
        ingredients.Cinnamon += 1;
        ingredients.Flour += 1;
        ingredients.Sugar += 1;

        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(1, leftoverIngredients.Apples);
        Assert.Equal(1, leftoverIngredients.Butter);
        Assert.Equal(1, leftoverIngredients.Cinnamon);
        Assert.Equal(1, leftoverIngredients.Flour);
        Assert.Equal(1, leftoverIngredients.Sugar);
    }

    [Fact]
    public void CalculateLeftOverIngredients_WithLessThanNeededQuantities_ReturnsCorrectLeftovers(){
        var applePie = new ApplePieRecipe();
        var ingredients = applePie.Ingredients;
        ingredients.Apples -= 1;
        ingredients.Butter -= 1;
        ingredients.Cinnamon -= 1;
        ingredients.Flour -= 1;
        ingredients.Sugar -= 1;

        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(ingredients.Apples, leftoverIngredients.Apples);
        Assert.Equal(ingredients.Butter, leftoverIngredients.Butter);
        Assert.Equal(ingredients.Cinnamon, leftoverIngredients.Cinnamon);
        Assert.Equal(ingredients.Flour, leftoverIngredients.Flour);
        Assert.Equal(ingredients.Sugar, leftoverIngredients.Sugar);
    }
}