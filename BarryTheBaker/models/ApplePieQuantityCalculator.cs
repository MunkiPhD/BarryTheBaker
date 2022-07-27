public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        public Tuple<int,int> MaxNumberOfPies(IDictionary<Ingredient, RecipeIngredient> availableIngredients){
            decimal usedApples = Math.Floor((decimal) availableIngredients[Ingredient.Apples].Quantity / recipe.Ingredients[Ingredient.Apples].Quantity);
            decimal usedSugar = Math.Floor((decimal) availableIngredients[Ingredient.Sugar].Quantity / recipe.Ingredients[Ingredient.Sugar].Quantity);
            // 1 stick = 8 tbsp, but we only need 6
            decimal totalTbspButter = Math.Floor( (decimal) availableIngredients[Ingredient.Butter].Quantity * 8); //TODO need to move this calculation to a better spot
            decimal usedButter = Math.Floor((decimal) totalTbspButter / recipe.Ingredients[Ingredient.Butter].Quantity);

            // flour is the denominator, but we need to make sure there is not another ingredient that we have less of
            var maxNumberOfIngredientsUsed = new List<decimal>(){usedApples, usedSugar, usedButter, availableIngredients[Ingredient.Flour].Quantity};
            int maxPies = (int)maxNumberOfIngredientsUsed.Min(); // Math.Min(Math.Min(usedApples, usedSugar), availabbleIngredients.Flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            int piesWithCinnamon = Math.Min(maxPies, (int)availableIngredients[Ingredient.Cinnamon].Quantity);
            return Tuple.Create(maxPies, piesWithCinnamon);
        }

        public IDictionary<Ingredient, RecipeIngredient> CalculateLeftOverIngredients(int maxPies, IDictionary<Ingredient, RecipeIngredient> availableIngredients){
            //TODO: this is a little verbose, but we can refactor later
            // figure out whole numbers of the ingredients we used
            var usedIngredients = new Dictionary<Ingredient, RecipeIngredient>();
            // usedIngredients.Add(Ingredient.Apples, new RecipeIngredient(Ingredient.Apples, recipe.Ingredients[Ingredient.Apples].Quantity * maxPies, recipe.Ingredients[Ingredient.Apples].Measurement));
            // usedIngredients.Add(Ingredient.Sugar, new RecipeIngredient(Ingredient.Apples, recipe.Ingredients[Ingredient.Apples].Quantity * maxPies, recipe.Ingredients[Ingredient.Apples].Measurement));
            // usedIngredients.Add(Ingredient.Flour, new RecipeIngredient(Ingredient.Apples, recipe.Ingredients[Ingredient.Apples].Quantity * maxPies, recipe.Ingredients[Ingredient.Apples].Measurement));
            // usedIngredients.Add(Ingredient.Cinnamon, new RecipeIngredient(Ingredient.Apples, recipe.Ingredients[Ingredient.Apples].Quantity * maxPies, recipe.Ingredients[Ingredient.Apples].Measurement));
            // usedIngredients.Add(Ingredient.Butter, new RecipeIngredient(Ingredient.Apples, recipe.Ingredients[Ingredient.Apples].Quantity * maxPies, recipe.Ingredients[Ingredient.Apples].Measurement));

            foreach(var item in recipe.Ingredients){
                RecipeIngredient ingredient = (RecipeIngredient) item.Value;
                usedIngredients.Add(ingredient.Ingredient, new RecipeIngredient(ingredient.Ingredient, ingredient.Quantity * maxPies, ingredient.Measurement));
            }

            // calculate how many ingredients we have left based on what was used
            // var remainingIngredients = new ApplePieIngredients(){
            //     Apples = availableIngredients[Ingredient.Apples] - usedIngredients.Apples,
            //     Sugar = availableIngredients[Ingredient.Sugar] - usedIngredients.Sugar,
            //     Flour = availableIngredients[Ingredient.Flour] - usedIngredients.Flour,
            //     Cinnamon = availableIngredients[Ingredient.Cinnamon] - usedIngredients.Cinnamon,
            //     Butter = availableIngredients[Ingredient.Butter] - usedIngredients.Butter,
            // };

            var remainingIngredients = new Dictionary<Ingredient, RecipeIngredient>();
            foreach(var item in usedIngredients){
                RecipeIngredient ingredient = (RecipeIngredient) item.Value;
                remainingIngredients.Add(ingredient.Ingredient, 
                                        new RecipeIngredient(
                                            ingredient.Ingredient,
                                            availableIngredients[ingredient.Ingredient].Quantity - usedIngredients[ingredient.Ingredient].Quantity, 
                                            ingredient.Measurement));
            } 

            return remainingIngredients;
        } 
    }