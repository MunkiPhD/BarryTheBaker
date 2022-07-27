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

                AskUserForInput("How many apples do you have?", Ingredient.Apples, MeasurementType.Unit);
                AskUserForInput("How much sugar do you have (in lbs)?", Ingredient.Sugar, MeasurementType.Pounds);
                AskUserForInput("How much flour do you have (in lbs)?", Ingredient.Flour, MeasurementType.Pounds);
                AskUserForInput("How much cinnamon do you have (in tsp)?", Ingredient.Cinnamon, MeasurementType.Tsp);
                AskUserForInput("How much sticks of butter do you have?", Ingredient.Butter, MeasurementType.Tbsp);
              

                // now we need to figure out how many pies we can make
                var applePieCalculator = new ApplePieQuantityCalculator();
                var pieCounts = applePieCalculator.MaxNumberOfPies(userInputIngredients);

                // and now, lets print some stuff
                Console.WriteLine($"\n\nYou can make: {pieCounts.Item1} apple pies!");
                Console.WriteLine($"   {pieCounts.Item2} apple pies with cinnamon");
                Console.WriteLine($"   {pieCounts.Item1 - pieCounts.Item2} apple pies WITHOUT cinnamon");

                var remainingIngredients = applePieCalculator.CalculateLeftOverIngredients(pieCounts.Item1, userInputIngredients);
                Console.WriteLine("You have the following ingredients left over:");
                Console.WriteLine($"   Apples {remainingIngredients[Ingredient.Apples].Quantity}");
                Console.WriteLine($"   Sugar {remainingIngredients[Ingredient.Sugar].Quantity}");
                Console.WriteLine($"   Flour {remainingIngredients[Ingredient.Flour].Quantity}");
                Console.WriteLine($"   Cinnamon {remainingIngredients[Ingredient.Cinnamon].Quantity}");
                Console.WriteLine($"   Butter {remainingIngredients[Ingredient.Butter].Quantity}");
            } while (!DoesUserWantToQuit());

        }

        public static bool DoesUserWantToQuit(){
            Console.WriteLine("If you wish to quit, use [Q/q]");
            var input = Console.ReadLine();
            return string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase);
        }

        private static void AskUserForInput(string question, Ingredient ingredient, MeasurementType measurement){
            Console.WriteLine(question);
            decimal userInput = 0;
            if(decimal.TryParse(Console.ReadLine(), out userInput)){
                // put the logic here to multiple sticks of butter into tbsp for now. Yes, this is a terrible place for it, i know
                if(ingredient == Ingredient.Butter) {
                    userInput *= 8;
                }
                userInputIngredients.Add(ingredient, new RecipeIngredient(ingredient, userInput, measurement));
            } else {
                Console.WriteLine("Must be a number!");
            } 
        }
    }
}