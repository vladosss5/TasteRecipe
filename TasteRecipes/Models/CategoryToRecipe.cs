using System;
using System.Collections.Generic;

namespace TasteRecipes.Models;

public partial class CategoryToRecipe : BaseModel
{
    public long CategoryId { get; set; }

    public long RecipeId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
