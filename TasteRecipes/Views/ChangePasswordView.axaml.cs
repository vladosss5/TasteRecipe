using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;

namespace TasteRecipes.Views;

public partial class ChangePasswordView : Window
{
    public ChangePasswordView()
    {
        InitializeComponent();
        DataContext = new ChangePasswordViewModel();
    }
}