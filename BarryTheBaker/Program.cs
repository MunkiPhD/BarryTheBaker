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
            int apples, sugar, flour, cinnamon, butter = 0;

            
            // this currently doesnt account for negative numbers
            do
            {
                Console.WriteLine("How many apples do you have?");
                if(!int.TryParse(Console.ReadLine(), out apples)){
                    Console.WriteLine("Must be a number");
                    continue;
                } 

                Console.WriteLine("How much sugar do you have (in lbs)?");
                if(!int.TryParse(Console.ReadLine(), out sugar)){
                    Console.WriteLine("Must be a number");
                    continue;
                }   

                Console.WriteLine("How much flour do you have (in lbs)?");
                if(!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine("Must be a number");
                    continue;
                }

                Console.WriteLine("How much cinnamon do you have (in tsp)?");
                if(!int.TryParse(Console.ReadLine(), out cinnamon)){
                    Console.WriteLine("Must be a number");
                    continue;
                }

                
                Console.WriteLine("How much sticks of butter do you have?");
                if(!int.TryParse(Console.ReadLine(), out butter)){
                    Console.WriteLine("Must be a number");
                    continue;
                }
                
                var userIngredientInput = new Dictionary<Ingredient, int>();
                userIngredientInput.Add(Ingredient.Apples, apples);
                userIngredientInput.Add(Ingredient.Sugar, sugar);
                userIngredientInput.Add(Ingredient.Flour, flour);
                userIngredientInput.Add(Ingredient.Butter, butter);
                userIngredientInput.Add(Ingredient.Cinnamon, cinnamon);
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
}