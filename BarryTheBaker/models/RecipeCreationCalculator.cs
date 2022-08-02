    public class RecipeCreationCalculator {
        public RecipeGenerationResults MaxQuantity(IRecipe recipe, IDictionary<Ingredient, RecipeIngredient> ingredientsAvailable){
            int maxNumberOfRecipe = int.MaxValue;

            // iterate over all the ingredients in the recipe
            foreach(var recipeIngredient in recipe.Ingredients){
                RecipeIngredient ingredient = recipeIngredient.Value;

                // determine how many pies we can create with the existing requirements for this recipe and based on what we have available
                int min = (int) Math.Floor(ingredientsAvailable[ingredient.Ingredient].Quantity / ingredient.Quantity);

                // if the number is zero, set it as the minimum
                maxNumberOfRecipe = Math.Min(maxNumberOfRecipe, min);
                // otherwise, take it if it's smaller
            }

            // now we are going to go through and actually subtract the quantity we need to make the pies from the ingredients available 
            // using the number of max quantity of the recipe that we can make
            foreach(var ingredient in recipe.Ingredients){
                RecipeIngredient recipeIngredient = ingredient.Value;
                var maxUsed = recipeIngredient.Quantity * maxNumberOfRecipe;
                var currentAvailable = ingredientsAvailable[recipeIngredient.Ingredient].Quantity;
                var availableQuantity = currentAvailable - maxUsed;
                ingredientsAvailable[recipeIngredient.Ingredient].Quantity = availableQuantity;
            }

            return new RecipeGenerationResults(){
               MaxQuantity = maxNumberOfRecipe, 
               RemainingIngredients = ingredientsAvailable
            };
        }
    }

    public class RecipeGenerationResults {
        public int MaxQuantity {get;set;}
        public IDictionary<Ingredient, RecipeIngredient> RemainingIngredients {get;set;}
    }