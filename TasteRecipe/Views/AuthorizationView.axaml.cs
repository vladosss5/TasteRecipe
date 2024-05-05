using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipe.ViewModels;

namespace TasteRecipe.Views;

public partial class AuthorizationView : Window
{
    public AuthorizationView()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}