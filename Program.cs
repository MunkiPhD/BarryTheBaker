using System;


namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core

            var applePieCalculator = new ApplePieQuantityCalculator();
            int apples = 0, sugar = 0, flour = 0, cinnamon = 0;
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
                
                var pieCounts = applePieCalculator.MaxNumberOfPies(apples, sugar, flour, cinnamon);
                Console.WriteLine($"\n\nYou can make: {pieCounts.Item1} apple pies!");
                Console.WriteLine($"   {pieCounts.Item2} apple pies with cinnamon");
                Console.WriteLine($"   {pieCounts.Item1 - pieCounts.Item2} apple pies WITHOUT cinnamon");

                var remainingIngredients = applePieCalculator.CalculateLeftOverIngredients(pieCounts.Item1, apples, sugar, flour, cinnamon);
                Console.WriteLine("You have the following ingredients left over:");
                Console.WriteLine($"   Apples {remainingIngredients.Apples}");
                Console.WriteLine($"   Sugar {remainingIngredients.Sugar}");
                Console.WriteLine($"   Flour {remainingIngredients.Flour}");
                Console.WriteLine($"   Cinnamon {remainingIngredients.Cinnamon}");

                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
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
        public Tuple<int,int> MaxNumberOfPies(int apples, int sugar, int flour, int cinnamon){
            var usedApples = apples / 3;
            var usedSugar = sugar / 2;
            var maxPies = Math.Min(Math.Min(usedApples, usedSugar), flour);
               
            // cinnamon is used until it is exhausted, so it's straight forward 
            // in that we just need the minimum since it's 1 tsp per 1 pie
            var piesWithCinnamon = Math.Min(maxPies, cinnamon);
            return Tuple.Create(maxPies, piesWithCinnamon);
        }

        public RemainingIngredients CalculateLeftOverIngredients(int maxPies, int apples, int sugar, int flour, int cinnamon){
            var remainingIngredients = new RemainingIngredients(){
                Apples = apples - (maxPies * 3),
                Sugar = sugar - (maxPies * 2),
                Flour = flour - maxPies,
                Cinnamon = Math.Max(cinnamon - maxPies, 0),
            };
            return remainingIngredients;
        } 
    }

    public class RemainingIngredients
    {
            public int Apples {get;set;}
            public int Sugar {get;set;}
            public int Flour {get;set;}
            public int Cinnamon {get;set;}
    }
}
