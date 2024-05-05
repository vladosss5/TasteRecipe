namespace TasteRecipe.Models;

public class Illustration : BaseModel
{
    public string Path { get; set; }
    public Recipe Recipe { get; set; }
}