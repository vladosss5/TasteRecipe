using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class CreateIngridientView : Window
{
    public CreateIngridientView()
    {
        InitializeComponent();
        DataContext = new CreateIngridientViewModel();
    }
}