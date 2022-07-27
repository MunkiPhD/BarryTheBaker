public class RecipeIngredient {
    public RecipeIngredient(Ingredient ingredient, decimal quantity, MeasurementType measurement){
        this.Ingredient = ingredient;
        this.Quantity = quantity;
        this.Measurement = measurement;
    }
    public Ingredient Ingredient;
    public decimal Quantity;
    public MeasurementType Measurement;
}