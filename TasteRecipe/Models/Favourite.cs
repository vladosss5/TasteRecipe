namespace TasteRecipe.Models;

public class Favourite : BaseModel
{
    public User User { get; set; }
    public Recipe Recipe { get; set; }
}