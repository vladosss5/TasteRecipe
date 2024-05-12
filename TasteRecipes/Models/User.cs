using System;
using System.Collections.Generic;

namespace TasteRecipes.Models;

public partial class User : BaseModel
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
