public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        public Tuple<int,int> MaxNumberOfPies(IDictionary<Ingredient, int> availableIngredients){
            decimal usedApples = Math.Floor((decimal) availableIngredients[Ingredient.Apples] / recipe.Ingredients[Ingredient.Apples]);
            decimal usedSugar = Math.Floor((decimal) availableIngredients[Ingredient.Sugar] / recipe.Ingredients[Ingredient.Sugar]);
            // 1 stick = 8 tbsp, but we only need 6
            decimal totalTbspButter = Math.Floor( (decimal) availableIngredients[Ingredient.ButterTbsp] * 8); //TODO need to move this calculation to a better spot
            decimal usedButter = Math.Floor((decimal) totalTbspButter / recipe.Ingredients[Ingredient.ButterTbsp]);

            // flour is the denominator, but we need to make sure there is not another ingredient that we have less of
            var maxNumberOfIngredientsUsed = new List<decimal>(){usedApples, usedSugar, usedButter, availableIngredients[Ingredient.Flour]};
            int maxPies = (int)maxNumberOfIngredientsUsed.Min(); // Math.Min(Math.Min(usedApples, usedSugar), availabbleIngredients.Flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            int piesWithCinnamon = Math.Min(maxPies, availableIngredients[Ingredient.Cinnamon]);
            return Tuple.Create(maxPies, piesWithCinnamon);
        }

        public ApplePieIngredients CalculateLeftOverIngredients(int maxPies, IDictionary<Ingredient, int> availableIngredients){
            //TODO: this is a little verbose, but we can refactor later
            // figure out whole numbers of the ingredients we used
            ApplePieIngredients usedIngredients = new ApplePieIngredients();
            usedIngredients.Apples = recipe.Ingredients[Ingredient.Apples] * maxPies;
            usedIngredients.Sugar = recipe.Ingredients[Ingredient.Sugar] * maxPies;
            usedIngredients.Flour = recipe.Ingredients[Ingredient.Flour] *  maxPies;
            usedIngredients.Cinnamon = recipe.Ingredients[Ingredient.Cinnamon] * maxPies;
            usedIngredients.Butter = recipe.Ingredients[Ingredient.ButterTbsp] * maxPies;

            // calculate how many ingredients we have left based on what was used
            var remainingIngredients = new ApplePieIngredients(){
                Apples = availableIngredients[Ingredient.Apples] - usedIngredients.Apples,
                Sugar = availableIngredients[Ingredient.Sugar] - usedIngredients.Sugar,
                Flour = availableIngredients[Ingredient.Flour] - usedIngredients.Flour,
                Cinnamon = availableIngredients[Ingredient.Cinnamon] - usedIngredients.Cinnamon,
                Butter = availableIngredients[Ingredient.ButterTbsp] - usedIngredients.Butter,
            };

            return remainingIngredients;
        } 
    }