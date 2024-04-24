using System.Collections.Generic;

namespace TasteRecipe.Models;

public class Category : BaseModel
{
    public string Name { get; set; }
    
    public List<CategoryToRecipe> CategoriesToRecipes { get; set; } = new List<CategoryToRecipe>();
}