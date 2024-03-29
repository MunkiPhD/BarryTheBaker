﻿using System;


namespace BarryTheBaker
{
    class BakeryStart
    {
        
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core
            // this currently doesnt account for negative numbers

            // going to create a list of recipes for now
            // TODO: use DI to provide a list of recipes
            Dictionary<int, IRecipe> recipeList = new Dictionary<int, IRecipe>();
            recipeList.Add(1, new ApplePieRecipe());
            recipeList.Add(2, new BlueberryCobblerRecipe());


            do
            {
                Console.WriteLine("Which recipe would you like to quantify?");
                foreach(var item in recipeList){
                    Console.WriteLine($"{item.Key} - {item.Value.Name}");
                }
                int recipeSelection = 0;
                if(int.TryParse(Console.ReadLine(), out recipeSelection)){
                    if(recipeList.ContainsKey(recipeSelection)){
                        IRecipe recipe = recipeList[recipeSelection];
                        var userInputs = CollectInputForRecipeSelection(recipe);

                        // create the generic calculator that will do stuff for us
                        var generationResults = new RecipeCreationCalculator().MaxQuantity(recipe, userInputs);
                        DisplayQuantityResultsToUser(generationResults);
                        
                    } else {
                        Console.WriteLine("That's not a valid selection!");
                    }
                };
            } while (!DoesUserWantToQuit());

        }

        public static void DisplayQuantityResultsToUser(RecipeGenerationResults results){
            ArgumentNullException.ThrowIfNull(results); // once it comes out of preview, can set parameter to be results!! which will null check the param
            
            // and now, lets print some stuff
            Console.WriteLine($"\n\nYou can make: {results.MaxQuantity} {results?.Recipe?.Name}!");
            //TODO: figure out how to print recipes quantities and recipe quantities with optionals
                // Console.WriteLine($"   {pieCounts.Item2} es with cinnamon");
                // Console.WriteLine($"   {pieCounts.Item1 - pieCounts.Item2} apple pies WITHOUT cinnamon");

            Console.WriteLine("You have the following ingredients remaining:");
            foreach(var ingredient in results.RemainingIngredients){
                RecipeIngredient recipeIngredient = ingredient.Value;
                Console.WriteLine($"   {recipeIngredient.Quantity} {recipeIngredient.Measurement} {recipeIngredient.Ingredient} ");    
            }
        }

        /// <summary>
        /// Collects input from the user of how much inventory of ingredients they have on hand for the selected recipe
        /// </summary>
        /// <param name="recipe">Recipe to calculate quantity of that can be made</param>
        /// <returns>Dictionary of the ingredient and how much of that ingredient is available</returns>        
        public static IDictionary<Ingredient, RecipeIngredient> CollectInputForRecipeSelection(IRecipe recipe){
             // everytime we go through the loop, we want to make sure we clear out all the items
            IDictionary<Ingredient, RecipeIngredient> userInputIngredients = new Dictionary<Ingredient, RecipeIngredient>();
            // this will need to get nuked once we add the cobbler
            
            foreach(var ingredient in recipe.Ingredients){
                RecipeIngredient recipeIngredient = ingredient.Value;
                var userIngredientInput = AskUserForIngredientQuantity($"Quantity of {recipeIngredient.Ingredient} ({recipeIngredient.Measurement}) in inventory?", recipeIngredient.Ingredient, recipeIngredient.Measurement);
                    if(userIngredientInput != null) {
                    userInputIngredients.Add(userIngredientInput.Ingredient, userIngredientInput);
                } else { 
                    break;
                }
            }

            return userInputIngredients;
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