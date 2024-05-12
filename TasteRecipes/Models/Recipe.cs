using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TasteRecipes.Models;

public partial class Recipe : BaseModel
{
    public string Name { get; set; } = null!;
    
    public int? Time { get; set; }
    
    public string? Instruction { get; set; }

    [NotMapped]
    public string Preview
    {
        get
        {
            if (Illustrations.Count == 0)
                return string.Empty;
            
            return Illustrations.ToList().FirstOrDefault().Path;
        } 
        set => value = value;
    }

    public long AuthorId { get; set; }

    public virtual User Author { get; set; } = null!;
    public virtual ICollection<CategoryToRecipe> CategoryToRecipes { get; set; } = new List<CategoryToRecipe>();
    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    public virtual ICollection<Illustration> Illustrations { get; set; } = new List<Illustration>();
    public virtual ICollection<IngridientToRecipe> IngridientToRecipes { get; set; } = new List<IngridientToRecipe>();
}
