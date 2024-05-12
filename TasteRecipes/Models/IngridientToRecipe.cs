using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteRecipes.Models;

public partial class IngridientToRecipe : BaseModel
{
    public long RecipeId { get; set; }

    public long IngredientId { get; set; }

    public string AmountIngredients { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
