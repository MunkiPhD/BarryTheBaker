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
        ingredients[Ingredient.Cinnamon] = 0;
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
        ingredients[Ingredient.Apples] += 1;
        ingredients[Ingredient.Butter] += 1;
        ingredients[Ingredient.Cinnamon] += 1;
        ingredients[Ingredient.Flour] += 1;
        ingredients[Ingredient.Sugar] += 1;

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
        var ingredients = IngredientList.CreateEmptyList();
        ingredients[Ingredient.Apples] = applePie.Ingredients[Ingredient.Apples]-1;
        ingredients[Ingredient.Butter] = applePie.Ingredients[Ingredient.Butter]-1;
        ingredients[Ingredient.Cinnamon] = applePie.Ingredients[Ingredient.Cinnamon]-1;
        ingredients[Ingredient.Flour] = applePie.Ingredients[Ingredient.Flour]-1;
        ingredients[Ingredient.Sugar] = applePie.Ingredients[Ingredient.Sugar]-1;

        var calculator = new ApplePieQuantityCalculator();
        var maxPies = calculator.MaxNumberOfPies(ingredients);
        
        var leftoverIngredients = calculator.CalculateLeftOverIngredients(maxPies.Item1, ingredients);
        Assert.Equal(ingredients[Ingredient.Apples], leftoverIngredients.Apples);
        Assert.Equal(ingredients[Ingredient.Butter], leftoverIngredients.Butter);
        Assert.Equal(ingredients[Ingredient.Cinnamon], leftoverIngredients.Cinnamon);
        Assert.Equal(ingredients[Ingredient.Flour], leftoverIngredients.Flour);
        Assert.Equal(ingredients[Ingredient.Sugar], leftoverIngredients.Sugar);
    }
}