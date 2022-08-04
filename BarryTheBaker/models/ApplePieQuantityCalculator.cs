//TODO: nuke this class
public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        /// <summary>
        /// Calculates the maximum number of apple pies you can make
        /// </summary>
        /// <param name="availableIngredients"></param>
        /// <returns>tuple with MaxPies, PiesWithCinnamon</returns>
        public Tuple<int,int> MaxNumberOfPies(IDictionary<Ingredient, RecipeIngredient> availableIngredients){
            var calculator = new RecipeCreationCalculator();
            var results = calculator.MaxQuantity(new ApplePieRecipe(), availableIngredients);
            decimal piesWithCinnamon = availableIngredients[Ingredient.Cinnamon].Quantity - results.RemainingIngredients[Ingredient.Cinnamon].Quantity;
            return Tuple.Create(results.MaxQuantity, (int) piesWithCinnamon);
        }

        /// <summary>
        /// Returns the left overs from makign the maximum number of apple pies possible
        /// </summary>
        /// <param name="maxPies"></param>
        /// <param name="availableIngredients"></param>
        /// <returns></returns>
        public IDictionary<Ingredient, RecipeIngredient> CalculateLeftOverIngredients(int maxPies, IDictionary<Ingredient, RecipeIngredient> availableIngredients){
            var calculator = new RecipeCreationCalculator();
            var results = calculator.MaxQuantity(new ApplePieRecipe(), availableIngredients);
            return results.RemainingIngredients;
        } 
    }