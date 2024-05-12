using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class AddCategoryView : Window
{
    public AddCategoryView()
    {
        InitializeComponent();
        DataContext = new AddCategoryViewModel();
    }
}