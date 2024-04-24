using System.Collections.Generic;

namespace TasteRecipe.Models;

public class Ingredient : BaseModel
{
    public string Name { get; set; }
    
    public List<IngridientToRecipe> IngridientsToRecipes { get; set; } = new List<IngridientToRecipe>();
}