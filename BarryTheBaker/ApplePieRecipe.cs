using BarryTheBaker;

public class ApplePieRecipe {
        public readonly ApplePieIngredients Ingredients;

        public ApplePieRecipe(){
            Ingredients = new ApplePieIngredients {
                Apples = 2,
                Sugar = 2,
                Flour = 1,
                Cinnamon = 1,
                Butter = 6, // in tbsp
            };
        }
    }