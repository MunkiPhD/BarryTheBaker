/// <summary>
/// Used to determine quantities of recipes that can be createed
/// </summary>
public class RecipeCreationCalculator {
    /// <summary>
    /// Determine the max number of the specified recipe that can be created with the available list of ingredients
    /// </summary>
    /// <param name="recipe">The recipe of the item you want to make</param>
    /// <param name="ingredientsAvailable">The inventory stock</param>
    /// <returns></returns>
    public RecipeGenerationResults MaxQuantity(IRecipe recipe, IDictionary<Ingredient, RecipeIngredient> ingredientsAvailable){
        int maxNumberOfRecipe = int.MaxValue;

        // iterate over all the ingredients in the recipe
        foreach(var recipeIngredient in recipe.Ingredients){
            RecipeIngredient ingredient = recipeIngredient.Value;

            // if it is required, then it will limit the number of pies we can make. otherwise, skip it
            if(!ingredient.Required){
                continue;
            }

            // determine how many pies we can create with the existing requirements for this recipe and based on what we have available
            int min = (int) Math.Floor(ingredientsAvailable[ingredient.Ingredient].Quantity / ingredient.Quantity);

            
            
            // if the number is zero, set it as the minimum
            maxNumberOfRecipe = Math.Min(maxNumberOfRecipe, min);
            // otherwise, take it if it's smaller
        }

        // now we are going to go through and actually subtract the quantity we need to make the pies from the ingredients available 
        // using the number of max quantity of the recipe that we can make
        var remainingIngredients = new Dictionary<Ingredient, RecipeIngredient>();
        foreach(var ingredient in recipe.Ingredients){
            RecipeIngredient recipeIngredient = ingredient.Value;
            var maxUsed = recipeIngredient.Quantity * maxNumberOfRecipe;
            var currentAvailable = ingredientsAvailable[recipeIngredient.Ingredient].Quantity;
            var availableQuantity = Math.Max(0, currentAvailable - maxUsed); // we want the maximum in case we dip below zero
            remainingIngredients.Add(recipeIngredient.Ingredient, new RecipeIngredient(recipeIngredient.Ingredient, availableQuantity, recipeIngredient.Measurement));
        }

        return new RecipeGenerationResults(){
            MaxQuantity = maxNumberOfRecipe, 
            RemainingIngredients = remainingIngredients
        };
    }
}

public class RecipeGenerationResults {
    public int MaxQuantity {get;set;}
    public IDictionary<Ingredient, RecipeIngredient> RemainingIngredients {get;set;}
}