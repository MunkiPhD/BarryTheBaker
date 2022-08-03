public class RecipeIngredient {
    public RecipeIngredient(Ingredient ingredient, decimal quantity, MeasurementType measurement, bool required = true){
        this.Ingredient = ingredient;
        this.Quantity = quantity;
        this.Measurement = measurement;
        this.Required = required;
    }
    
    public Ingredient Ingredient;
    public decimal Quantity;
    public MeasurementType Measurement;
    public bool Required;
}