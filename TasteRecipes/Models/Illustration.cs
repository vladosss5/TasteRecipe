using System;
using System.Collections.Generic;

namespace TasteRecipes.Models;

public partial class Illustration : BaseModel
{
    public string Path { get; set; } = null!;

    public long RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
