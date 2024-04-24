namespace TasteRecipe.Models;

public class Favourite
{
    public User User { get; set; }
    public Recipe Recipe { get; set; }
}