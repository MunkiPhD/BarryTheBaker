public class BlueberryCobblerRecipe {
    public readonly IDictionary<Ingredient, int> Ingredients;

    public BlueberryCobblerRecipe(){
        Ingredients = new Dictionary<Ingredient, int>();
        Ingredients.Add(Ingredient.Blueberries, 4);
        Ingredients.Add(Ingredient.LemonZest, 1);
        Ingredients.Add(Ingredient.ButterTbsp, 5);
        Ingredients.Add(Ingredient.Flour, 1);
        Ingredients.Add(Ingredient.Sugar, 1);
        Ingredients.Add(Ingredient.Milk, 1);
        Ingredients.Add(Ingredient.Cinnamon, 1);
    }
}

public enum Ingredient {
    Apples,
    Sugar,
    Flour,
    ButterTbsp,
    Blueberries,
    LemonZest,
    Milk,
    Cinnamon,
}