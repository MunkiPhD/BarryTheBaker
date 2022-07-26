public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        public Tuple<int,int> MaxNumberOfPies(ApplePieIngredients availableIngredients){
            var usedApples = availableIngredients.Apples / recipe.Ingredients.Apples;
            var usedSugar = availableIngredients.Sugar / recipe.Ingredients.Sugar;
            // 1 stick = 8 tbsp, but we only need 6
            var totalTbspButter = availableIngredients.Butter * 8; //TODO need to move this calculation to a better spot
            var usedButter = totalTbspButter / recipe.Ingredients.Butter;

            // flour is the denominator, but we need to make sure there is not another ingredient that we have less of
            var maxNumberOfIngredientsUsed = new List<int>(){usedApples, usedSugar, usedButter, availableIngredients.Flour};
            var maxPies = maxNumberOfIngredientsUsed.Min(); // Math.Min(Math.Min(usedApples, usedSugar), availabbleIngredients.Flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            var piesWithCinnamon = Math.Min(maxPies, availableIngredients.Cinnamon);
            return Tuple.Create(maxPies, piesWithCinnamon);
        }

        public ApplePieIngredients CalculateLeftOverIngredients(int maxPies, ApplePieIngredients availableIngredients){
            var remainingIngredients = new ApplePieIngredients(){
                Apples = availableIngredients.Apples - (maxPies * 3),
                Sugar = availableIngredients.Sugar - (maxPies * 2),
                Flour = availableIngredients.Flour - maxPies,
                Cinnamon = Math.Max(availableIngredients.Cinnamon - maxPies, 0),
                Butter = (availableIngredients.Butter * 8) - (maxPies * 6),
            };
            return remainingIngredients;
        } 
    }