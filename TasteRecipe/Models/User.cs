using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace TasteRecipe.Models;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }

    public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    public List<Favourite> Favourites { get; set; } = new List<Favourite>();
}