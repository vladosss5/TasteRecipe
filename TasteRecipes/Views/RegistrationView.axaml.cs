using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class RegistrationView : Window
{
    public RegistrationView()
    {
        InitializeComponent();
        DataContext = new RegistrationViewModel();
    }
}