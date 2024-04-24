using System;
using System.Collections.Generic;

namespace TasteRecipe.Models;

public class Recipe : BaseModel
{
    public string Name { get; set; }
    public int? Time { get; set; }
    public int[]? EnergyValue { get; set; }
    public User Author { get; set; }
    
    public List<Illustration>? Illustrations { get; set; } = new List<Illustration>();
    public List<CategoryToRecipe>? CategoriesToRecipes { get; set; } = new List<CategoryToRecipe>();
    public List<Favourite>? Favourites { get; set; } = new List<Favourite>();
    public List<IngridientToRecipe>? IngridientsToRecipes { get; set; } = new List<IngridientToRecipe>();
}