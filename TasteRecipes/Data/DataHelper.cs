using TasteRecipes.Data.Context;

namespace TasteRecipes.Data;

public class DataHelper
{
    private static DataContext _dataContext;

    public static DataContext GetContext()
    {
        return _dataContext ??= new DataContext();
    }
}