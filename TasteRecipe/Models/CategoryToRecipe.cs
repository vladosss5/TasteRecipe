namespace TasteRecipe.Models;

public class CategoryToRecipe : BaseModel
{
    public Category Category { get; set; }
    public Recipe Recipe { get; set; }
}