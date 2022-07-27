public static class IngredientList {
    public static IDictionary<Ingredient, RecipeIngredient> CreateEmptyList(){
        IDictionary<Ingredient, RecipeIngredient> newList = new Dictionary<Ingredient, RecipeIngredient>();
        newList.Add(Ingredient.Apples, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Sugar, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Flour, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Butter, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Blueberries, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.LemonZest, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Milk, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));
        newList.Add(Ingredient.Cinnamon, new RecipeIngredient(Ingredient.Apples, 0, MeasurementType.Unit));

        return newList;
    }
}