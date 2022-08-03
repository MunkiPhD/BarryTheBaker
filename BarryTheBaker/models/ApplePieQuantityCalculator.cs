public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableIngredients"></param>
        /// <returns>tuple with MaxPies, PiesWithCinnamon</returns>
        public Tuple<int,int> MaxNumberOfPies(IDictionary<Ingredient, RecipeIngredient> availableIngredients){
            var calculator = new RecipeCreationCalculator();
            var results = calculator.MaxQuantity(new ApplePieRecipe(), availableIngredients);
            decimal piesWithCinnamon = availableIngredients[Ingredient.Cinnamon].Quantity - results.RemainingIngredients[Ingredient.Cinnamon].Quantity;
            return Tuple.Create(results.MaxQuantity, (int) piesWithCinnamon);
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