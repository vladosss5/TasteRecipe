using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteRecipes.Models;

public partial class Ingredient  : BaseModel
{
    public string Name { get; set; } = null!;
    
    [NotMapped] public bool SelectIngridient { get; set; } = false;
    public virtual ICollection<IngridientToRecipe> IngridientToRecipes { get; set; } = new List<IngridientToRecipe>();
}
