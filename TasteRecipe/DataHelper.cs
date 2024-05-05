﻿using TasteRecipe.Data.Context;

namespace TasteRecipe;

public class DataHelper
{
    private static DataContext _dataContext;

    public static DataContext GetContext()
    {
        return _dataContext ??= new DataContext();
    }
}