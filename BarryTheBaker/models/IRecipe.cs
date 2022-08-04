
public interface IRecipe {
    IDictionary<Ingredient, RecipeIngredient> Ingredients {get;}
    String Name {get;}
}