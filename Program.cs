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
            int apples = 0, sugar = 0, flour = 0;
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

                Console.WriteLine("How much sugar do you have (in lbs)?");
                if(!int.TryParse(Console.ReadLine(), out flour)){
                    Console.WriteLine("Must be a number");
                    continue;
                }  
                
                int maxPies = applePieCalculator.MaxNumberOfPies(apples, sugar, flour);
                Console.WriteLine($"\n\nYou can make: {maxPies} apple pies!");

                var remainingIngredients = applePieCalculator.CalculateLeftOverIngredients(maxPies, apples, sugar, flour);
                Console.WriteLine("You have the following ingredients left over:");
                Console.WriteLine($"   Apples {remainingIngredients.Apples}");
                Console.WriteLine($"   Sugar {remainingIngredients.Sugar}");
                Console.WriteLine($"   Flour {remainingIngredients.Flour}");

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
        public int MaxNumberOfPies(int apples, int sugar, int flour){
            var usedApples = apples / 3;
            var usedSugar = sugar / 2;
            var maxPies = Math.Min(Math.Min(usedApples, usedSugar), flour);
               
            return maxPies;
        }

        public RemainingIngredients CalculateLeftOverIngredients(int maxPies, int apples, int sugar, int flour){
            var remainingIngredients = new RemainingIngredients(){
                Apples = apples - (maxPies * 3),
                Sugar = sugar - (maxPies * 2),
                Flour = flour - maxPies
            };
            return remainingIngredients;
        } 
    }

    public class RemainingIngredients
    {
            public int Apples {get;set;}
            public int Sugar {get;set;}
            public int Flour {get;set;}
    }
}
