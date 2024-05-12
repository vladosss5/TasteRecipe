using System;
using System.Collections.Generic;

namespace TasteRecipes.Models;

public partial class Favourite : BaseModel
{
    public long UserId { get; set; }

    public long RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
