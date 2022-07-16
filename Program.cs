using System;


namespace BarryTheBaker
{
    class BakeryStart
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core

            var applePieCalculator = new ApplePieQuantityCalculator();
            var userIngredientInput = new ApplePieIngredients(){
                   Apples =  0, 
                   Sugar = 0, 
                   Flour = 0, 
                   Cinnamon = 0,
                   Butter = 0
                };
            
            // this currently doesnt account for negative numbers
            do
            {
                Console.WriteLine("How many apples do you have?");
                if(!int.TryParse(Console.ReadLine(), out userIngredientInput.Apples)){
                    Console.WriteLine("Must be a number");
                    continue;
                } 

                Console.WriteLine("How much sugar do you have (in lbs)?");
                if(!int.TryParse(Console.ReadLine(), out userIngredientInput.Sugar)){
                    Console.WriteLine("Must be a number");
                    continue;
                }   

                Console.WriteLine("How much flour do you have (in lbs)?");
                if(!int.TryParse(Console.ReadLine(), out userIngredientInput.Flour)){
                    Console.WriteLine("Must be a number");
                    continue;
                }

                Console.WriteLine("How much cinnamon do you have (in tsp)?");
                if(!int.TryParse(Console.ReadLine(), out userIngredientInput.Cinnamon)){
                    Console.WriteLine("Must be a number");
                    continue;
                }

                
                Console.WriteLine("How much sticks of butter do you have?");
                if(!int.TryParse(Console.ReadLine(), out userIngredientInput.Butter)){
                    Console.WriteLine("Must be a number");
                    continue;
                }
                
                // now we need to figure out how many pies we can make
                var pieCounts = applePieCalculator.MaxNumberOfPies(userIngredientInput);


                // and now, lets print some stuff
                Console.WriteLine($"\n\nYou can make: {pieCounts.Item1} apple pies!");
                Console.WriteLine($"   {pieCounts.Item2} apple pies with cinnamon");
                Console.WriteLine($"   {pieCounts.Item1 - pieCounts.Item2} apple pies WITHOUT cinnamon");

                var remainingIngredients = applePieCalculator.CalculateLeftOverIngredients(pieCounts.Item1, userIngredientInput);
                Console.WriteLine("You have the following ingredients left over:");
                Console.WriteLine($"   Apples {remainingIngredients.Apples}");
                Console.WriteLine($"   Sugar {remainingIngredients.Sugar}");
                Console.WriteLine($"   Flour {remainingIngredients.Flour}");
                Console.WriteLine($"   Cinnamon {remainingIngredients.Cinnamon}");
                Console.WriteLine($"   Butter {remainingIngredients.Butter}");
            } while (!DoesUserWantToQuit());

        }

        public static bool DoesUserWantToQuit(){
            Console.WriteLine("If you wish to quit, use [Q/q]");
            var input = Console.ReadLine();
            return string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase);
        }
    }

    public class ApplePieQuantityCalculator
    {
        private ApplePieRecipe recipe;

        public ApplePieQuantityCalculator(){
            recipe = new ApplePieRecipe();
        }

        public Tuple<int,int> MaxNumberOfPies(ApplePieIngredients availabbleIngredients){
            var usedApples = availabbleIngredients.Apples / recipe.Ingredients.Apples;
            var usedSugar = availabbleIngredients.Sugar / recipe.Ingredients.Sugar;
            // 1 stick = 8 tbsp, but we only need 6
            var totalTbspButter = availabbleIngredients.Butter * 8; //TODO need to move this calculation to a better spot
            var usedButter = totalTbspButter / recipe.Ingredients.Butter;

            // flour is the denominator, but we need to make sure there is not another ingredient that we have less of
            var maxNumberOfIngredientsUsed = new List<int>(){usedApples, usedSugar, usedButter, availabbleIngredients.Flour};
            var maxPies = maxNumberOfIngredientsUsed.Min(); // Math.Min(Math.Min(usedApples, usedSugar), availabbleIngredients.Flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            var piesWithCinnamon = Math.Min(maxPies, availabbleIngredients.Cinnamon);
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

    public class ApplePieIngredients
    {
            public int Apples;
            public int Sugar;
            public int Flour;
            public int Cinnamon;
            public int Butter; // in tbsp
    }
}

