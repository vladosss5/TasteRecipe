using Avalonia.Controls;
using TasteRecipes.Models;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public void DeleteOnFavorite(Favourite favourite)
    {
        (DataContext as MainWindowViewModel).DeleteOnFavoriteImpl(favourite);
    }
    
    public void DeleteRecipe(Recipe recipe)
    {
        (DataContext as MainWindowViewModel).DeleteRecipeImpl(recipe);
    }

    public void AddFavorite(Recipe recipe)
    {
        (DataContext as MainWindowViewModel).AddFavoriteImpl(recipe);
    }
}
