namespace TasteRecipe.Models;

public class IngridientToRecipe : BaseModel
{
    public Recipe Recipe { get; set; }
    public Ingredient Ingredient { get; set; }
    public string AmountIngredients { get; set; }
}