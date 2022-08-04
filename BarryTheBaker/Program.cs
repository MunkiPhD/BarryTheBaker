using System;


namespace BarryTheBaker
{
    class BakeryStart
    {
        private static Dictionary<Ingredient, RecipeIngredient> userInputIngredients = new Dictionary<Ingredient, RecipeIngredient>();
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core
            // this currently doesnt account for negative numbers
            do
            {
                // everytime we go through the loop, we want to make sure we clear out all the items
                userInputIngredients.Clear();

                // this will need to get nuked once we add the cobbler
                IRecipe applePieRecipe = new ApplePieRecipe();

                foreach(var ingredient in applePieRecipe.Ingredients){
                    RecipeIngredient recipeIngredient = ingredient.Value;
                    var userIngredientInput = AskUserForIngredientQuantity($"Quantity of {recipeIngredient.Ingredient} in inventory?", recipeIngredient.Ingredient, recipeIngredient.Measurement);
                     if(userIngredientInput != null) {
                        userInputIngredients.Add(userIngredientInput.Ingredient, userIngredientInput);
                    } else { 
                        break;
                    }
                }

                // now we need to figure out how many pies we can make
                var applePieCalculator = new ApplePieQuantityCalculator();
                var pieCounts = applePieCalculator.MaxNumberOfPies(userInputIngredients);

                // and now, lets print some stuff
                Console.WriteLine($"\n\nYou can make: {pieCounts.Item1} apple pies!");
                Console.WriteLine($"   {pieCounts.Item2} apple pies with cinnamon");
                Console.WriteLine($"   {pieCounts.Item1 - pieCounts.Item2} apple pies WITHOUT cinnamon");

                var remainingIngredients = applePieCalculator.CalculateLeftOverIngredients(pieCounts.Item1, userInputIngredients);
                Console.WriteLine("You have the following ingredients remaining:");
                foreach(var ingredient in remainingIngredients){
                    RecipeIngredient recipeIngredient = ingredient.Value;
                    Console.WriteLine($"   {recipeIngredient.Ingredient} {remainingIngredients[recipeIngredient.Ingredient].Quantity}");    
                }
            } while (!DoesUserWantToQuit());

        }

        public static bool DoesUserWantToQuit(){
            Console.WriteLine("If you wish to quit, use [Q/q]");
            var input = Console.ReadLine();
            return string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase);
        }


        private static RecipeIngredient AskUserForIngredientQuantity(string question, Ingredient ingredient, MeasurementType measurement){
            Console.WriteLine(question);
            decimal userInput = 0;
            if(decimal.TryParse(Console.ReadLine(), out userInput)){
                // put the logic here to multiple sticks of butter into tbsp for now. Yes, this is a terrible place for it, i know
                if(ingredient == Ingredient.Butter) {
                    userInput *= 8;
                }
                return new RecipeIngredient(ingredient, userInput, measurement);
            } else {
                Console.WriteLine("Must be a number!");
                return null;
            } 
        }

    }
}