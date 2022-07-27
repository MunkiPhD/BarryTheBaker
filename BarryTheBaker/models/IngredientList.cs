public static class IngredientList {
    public static IDictionary<Ingredient, int> CreateEmptyList(){
        IDictionary<Ingredient, int> newList = new Dictionary<Ingredient, int>();
        newList.Add(Ingredient.Apples, 0);
        newList.Add(Ingredient.Sugar, 0);
        newList.Add(Ingredient.Flour, 0);
        newList.Add(Ingredient.ButterTbsp, 0);
        newList.Add(Ingredient.Blueberries, 0);
        newList.Add(Ingredient.LemonZest, 0);
        newList.Add(Ingredient.Milk, 0);
        newList.Add(Ingredient.Cinnamon, 0);

        return newList;
    }
}