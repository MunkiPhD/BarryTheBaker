public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        public Tuple<int,int> MaxNumberOfPies(ApplePieIngredients availableIngredients){
            decimal usedApples = Math.Floor((decimal) availableIngredients.Apples / recipe.Ingredients.Apples);
            decimal usedSugar = Math.Floor((decimal) availableIngredients.Sugar / recipe.Ingredients.Sugar);
            // 1 stick = 8 tbsp, but we only need 6
            decimal totalTbspButter = Math.Floor( (decimal) availableIngredients.Butter * 8); //TODO need to move this calculation to a better spot
            decimal usedButter = Math.Floor((decimal) totalTbspButter / recipe.Ingredients.Butter);

            // flour is the denominator, but we need to make sure there is not another ingredient that we have less of
            var maxNumberOfIngredientsUsed = new List<decimal>(){usedApples, usedSugar, usedButter, availableIngredients.Flour};
            int maxPies = (int)maxNumberOfIngredientsUsed.Min(); // Math.Min(Math.Min(usedApples, usedSugar), availabbleIngredients.Flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            int piesWithCinnamon = Math.Min(maxPies, availableIngredients.Cinnamon);
            return Tuple.Create(maxPies, piesWithCinnamon);
        }

        public ApplePieIngredients CalculateLeftOverIngredients(int maxPies, ApplePieIngredients availableIngredients){
            //TODO: this is a little verbose, but we can refactor later
            // figure out whole numbers of the ingredients we used
            ApplePieIngredients usedIngredients = new ApplePieIngredients();
            usedIngredients.Apples = recipe.Ingredients.Apples * maxPies;
            usedIngredients.Sugar = recipe.Ingredients.Sugar * maxPies;
            usedIngredients.Flour = recipe.Ingredients.Flour *  maxPies;
            usedIngredients.Cinnamon = recipe.Ingredients.Cinnamon * maxPies;
            usedIngredients.Butter = recipe.Ingredients.Butter * maxPies;

            // calculate how many ingredients we have left based on what was used
            var remainingIngredients = new ApplePieIngredients(){
                Apples = availableIngredients.Apples - usedIngredients.Apples,
                Sugar = availableIngredients.Sugar - usedIngredients.Sugar,
                Flour = availableIngredients.Flour - usedIngredients.Flour,
                Cinnamon = availableIngredients.Cinnamon - usedIngredients.Cinnamon,
                Butter = availableIngredients.Butter - usedIngredients.Butter,
            };

            return remainingIngredients;
        } 
    }