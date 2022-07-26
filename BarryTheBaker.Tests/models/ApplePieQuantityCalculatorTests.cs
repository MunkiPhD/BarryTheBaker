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

    [Fact(Skip="WIP")]
    public void CalculateLeftOverIngredients_WithExactIngredients_ReturnsZeroLeftovers(){

    }
}