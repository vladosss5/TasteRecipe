using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteRecipes.Models;

public partial class Category : BaseModel
{
    public string Name { get; set; } = null!;

    [NotMapped] 
    public bool SelectCategory { get; set; } = false;
    public virtual ICollection<CategoryToRecipe> CategoryToRecipes { get; set; } = new List<CategoryToRecipe>();
}
