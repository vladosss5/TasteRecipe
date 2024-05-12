using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class AuthorizationView : Window
{
    public AuthorizationView()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}